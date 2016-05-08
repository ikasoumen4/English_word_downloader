using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
//using Android.Support.V4.App Android 1.6 (API level 4) 以降を対象としたライブラリで、Fragment などが使えるようになる。
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using System.Threading.Tasks;
using HelloWorld.Functions;

namespace HelloWorld.Fragments
{

    public interface IQuiz
    {
        bool IsDownloaded { get; set; }
        string word { get; set; }
        string mean { get; set; }
        string sound_path { get; set; }
    }

    public class QuizData : IQuiz
    {
        public bool IsDownloaded { get; set; }
        public string mean { get; set; }
        public string sound_path { get; set; }
        public string word { get; set; }

    }





    public class Quiz : Fragment, IQuiz
    {

        #region quiz interface

        public bool IsDownloaded { get; set; }

        TextView _word;
        public string word
        {
            get
            {
                return _word.Text;
            }

            set
            {
                _word.Text = value;
            }
        }

        TextView _mean;
        public string mean
        {
            get
            {
                return _mean.Text;
            }

            set
            {
                _mean.Text = value;
            }
        }

        public string sound_path { get; set; }

        #endregion

        #region Fragment Define


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

            //var button = Activity.FindViewById<Button>(Resource.Id.MyButton);


            //var transactoin = ChildFragmentManager.BeginTransaction();
            //transactoin.Commit();


        }


        Android.Media.SoundPool soundpool = new Android.Media.SoundPool(
                    maxStreams: 1,
                    streamType: Android.Media.Stream.Music,
                    srcQuality: 0
                    );

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Quiz, container, false);

            #region view bind

            _word = view.FindViewById<TextView>(Resource.Id.MySuperTextView);
            _mean = view.FindViewById<TextView>(Resource.Id.text_mean);


            var btn_play = view.FindViewById<Button>(Resource.Id.btn_playsound);
            var btn_previous = view.FindViewById<ImageButton>(Resource.Id.btn_quiz_previous);
            var btn_next = view.FindViewById<ImageButton>(Resource.Id.btn_quiz_next);
            var btn_show_answer = view.FindViewById<Button>(Resource.Id.btn_show_answer);

            #endregion


            btn_previous.Click += async delegate { await Previous(); };
            btn_next.Click += async delegate { await Next(); };
            btn_show_answer.Click += delegate { _word.Visibility = ViewStates.Visible; };


            soundpool.LoadComplete += (obj, arg) =>
            {

                //if (file_id == -1) return;
                soundpool.Play(
                    soundID: arg.SampleId,
                    leftVolume: 1,
                    rightVolume: 1,
                    priority: 0,    //0が一番優先度が高い
                    loop: 0,        //-1 無限ループ　0 ループしない
                    rate: 0         //再生速度 0.5　～ 2.0
                );

                //soundpool.Unload(arg.SampleId); //特定のリソースのみ解放
                //soundpool.Release();    //使い終わったら解放

            };

            btn_play.Click += delegate
            {
                //if (IsDownloading) return;

                //var soundpool = new Android.Media.SoundPool(
                //    maxStreams: 1,
                //    streamType: Android.Media.Stream.Music,
                //    srcQuality: 0
                //    );


                //第2引数のpriorityは現在は利用されていないみたいだが、互換性のために1を使用する。
                //soundpool.Load(sound_path, 1);
                PlaySound();

            };

            Init();
            return view;
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            //outState.PutInt(nameof(current_quiz_index), current_quiz_index);
            base.OnSaveInstanceState(outState); //呼ばないと多分エラーになる
        }

        public override void OnViewStateRestored(Bundle savedInstanceState)
        {
            //current_quiz_index = savedInstanceState.GetInt(nameof(current_quiz_index));
            base.OnViewStateRestored(savedInstanceState); //呼ばないと多分エラーになる
        }



        #endregion

        private List<QuizData> items;
        private int current_quiz_index = -1;


        private void Init()
        {
            items = new List<QuizData>();

            var arr = new string[] {
"extractor",
"flinger",
"fright",
"demux",
"theorem",
"periodicity",
"vertex",
"vertices",
"hypotenuse",
"adjacent",
"opposite",
"periodicity",
"radius",
"radian",
"geometry",
"Orthographic",
"Perspective",
"Euler",
"coordinate",
"orthogonal",
"oblique",
"cartesian",
"algebra",
"equation",
"quadrant",
"chirality",
"pole",
"polar",
"pincushion",
"distortion",
"coefficient",
"spherical",
"azimuth",
"zenith",
"altitude",
"elevation",
"longtitude",
"latitude",
"displacement",
"affine",
"scalar",
"commutative",
"transcendental",
"pseudo",
"axial",
"Jacobi",
"detection",
"diagonal",
"term",
"summation",
"transpose",
"invertible",
"swizzle",
"cofactor",
"parallelepiped",
"frustum",
"canonical",
"homogeneous",
"Euclidean",
"rigid",
"isometry",
"yaw",
"rational",
"irrational",
"singularity",
"interpolation",
"complex",
"imaginary",
"conjugate",
"norm",
"nilpotent",
"axes",
"isoclinic",
"kinematics",
"approximation",
"explicit",
"implicit",
"surface",
"polynomial",
"continuity",
"smooth",
"curvature",
"differentiation",
"derivaltive",
"delta",
"spline",
"weighted",
"bezier",
"hermite",
"boundary",
"intermediate",
"heterogeneous",
"reincarnation",
"optimize",
"variant",
"raytracing",
"punchthrough",
"stencil",
"depth",
"opaque",
"tessellation",
"diffuse",
"incident",
"attenuation",
"ambient",
"intensity",
"albedo",
"specular",
"exponent",
"varying",
"rim",
"tangent",
"sine",
"cosine",
"bitangent",
"radiance",
"roughness",
"refraction",
"trow",
"fourier",
"region"
            };

            foreach (var item in arr)
            {
                items.Add(new QuizData()
                {
                    word = item
                });
            }

            Next();
        }


        public void PlaySound(bool show_error_message = false)
        {

            if (IsDownloaded == false || sound_path == null)
            {
                if (show_error_message)
                {
                    Debug("音声の取得に失敗しました。");

                }

                return;
            }
            
            //第2引数のpriorityは現在は利用されていないみたいだが、互換性のために1を使用する。
            //var task = soundpool.LoadAsync(sound_path, 1);
            soundpool.Load(sound_path, 1);
            //task.Wait();

            //soundpool.Play(
            //        soundID: task.Result,
            //        leftVolume: 1,
            //        rightVolume: 1,
            //        priority: 0,    //0が一番優先度が高い
            //        loop: 0,        //-1 無限ループ　0 ループしない
            //        rate: 0         //再生速度 0.5　～ 2.0
            //    );

            //soundpool.Unload(task.Result);

        }

        private async Task Next()
        {

            this.InitQuizData();

            try
            {
                _word.Visibility = ViewStates.Invisible;
                current_quiz_index += 1;
                var data = items[current_quiz_index];


                //new AlertDialog.Builder(Activity)
                //.SetTitle("download")
                //.SetMessage("start!!")
                //.SetPositiveButton("OK", delegate { })
                //.Show();

                this.CopyQuizData(data);


                //word = data.word;
                //mean = "データの取得に失敗しました。";
                //IsDownloaded = false;

                var current = current_quiz_index;
                DownloadData(items[current_quiz_index + 1]);    //事前に次のページを読み込んでおく　最大値チェックとかしなきゃ
                await DownloadData(data);
                if (current == current_quiz_index) { this.CopyQuizData(data); }  //ページが変わっていなければ画面を更新
                

            }
            catch (System.IndexOutOfRangeException e)
            {
                current_quiz_index = -1;
            }
        }

        private async Task Previous()
        {
            this.InitQuizData();

            try
            {
                _word.Visibility = ViewStates.Invisible;
                current_quiz_index -= 1;
                var data = items[current_quiz_index];

                this.CopyQuizData(data);

                //word = data.word;
                //mean = "";
                //IsDownloaded = false;

                var current = current_quiz_index;
                await DownloadData(data);
                if (current == current_quiz_index) { this.CopyQuizData(data); }  //ページが変わっていなければ画面を更新

            }
            catch (System.IndexOutOfRangeException e)
            {
                current_quiz_index = -1;
            }
        }



        private async Task DownloadData(IQuiz quiz)
        {

            quiz.IsDownloaded = false;

            var word_path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/words/" + quiz.word;
            quiz.sound_path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/sounds/" + quiz.word;

            var word_path_exists = System.IO.File.Exists(word_path);
            var sound_path_exist = System.IO.File.Exists(quiz.sound_path);

            if (word_path_exists == false || sound_path_exist == false)
            {

                var doc = new Scraping.en_hatsuon_info();

                try
                {
                    await doc.DownloadhtmlAsync(quiz.word);

                    quiz.mean = doc.GetMeaning();

                    var data = await Functions.API.DownloadFileAsync(doc.GetSoundSourceURL());

                    await Functions.API.SaveTextFile(word_path, doc.GetMeaning());

                    await Functions.API.SaveByteFile(quiz.sound_path, data);

                }
                catch (Exception e)
                {
                    quiz.mean = "error :" + e.Message;
                    quiz.sound_path = "";
                }


            }else
            {
                quiz.mean = System.IO.File.ReadAllText(word_path);
            }


            quiz.IsDownloaded = true;


        }



        public void Debug(string message)
        {
            new AlertDialog.Builder(Activity)
                .SetTitle(message)
                .SetPositiveButton("OK", delegate { })
                .Show();
        }
        


    }
}