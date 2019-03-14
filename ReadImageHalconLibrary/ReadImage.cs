using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using MultTree;



namespace ReadImageHalconLibrary
{
    #region   取图方式的枚举
    /// <summary>
    /// 取图方式的枚举
    /// </summary>
    public enum Acquire
    {
        /// <summary>
        /// 注册表取图1
        /// </summary>
        Registry_Image_One,

        /// <summary>
        /// 注册表取图2
        /// </summary>
        Registry_Image_Two,

        /// <summary>
        /// 文件夹
        /// </summary>     
        Folder_Image,
    }
    #endregion

    #region  注册表指针
    /// <summary>
    /// 注册表指针
    /// </summary>
    unsafe public static class IntPtrRegistry
    {
        #region 静态相机像素

        #region  第一个注册表
        /// <summary>
        /// Number of pixel columns in camera
        /// </summary>
        static public uint STRIDE_ONE = 3000;               /* Number of pixel columns in camera */

        /// <summary>
        /// Number of pixel rows in image
        /// </summary>
        static public uint NUMROWS_ONE = 1700;            /* Number of pixel rows in image */

        /// <summary>
        /// 第一个相机注册表,使用注册表指针，只能采用赋值的方式
        /// </summary>
        public static IntPtr Registry_Image_One;
        #endregion

        #region  第二个注册表
        /// <summary>
        /// Number of pixel columns in camera
        /// </summary>
        static public uint STRIDE_TWO = 3000;               /* Number of pixel columns in camera */

        /// <summary>
        /// Number of pixel rows in image
        /// </summary>
        static public uint NUMROWS_TWO = 1700;            /* Number of pixel rows in image */

        /// <summary>
        /// 第二个相机注册表,使用注册表指针，只能采用赋值的方式
        /// </summary>
        public static IntPtr Registry_Image_Two;
        #endregion

        #endregion
    }
    #endregion

    #region  取图工具的数据
    /// <summary>
    /// 取图工具的数据
    /// </summary>
    [Serializable]
    public class ReadShuJu : MultTree.ToolDateFather, IReadShuJu
    {
        #region  图片数据
        /// <summary>
        /// 图片数据
        /// </summary>
        [NonSerialized]
        private HObject ho_image;
        #endregion

        #region  注册表
        /// <summary>
        /// 注册表.宽
        /// </summary>
        uint _width = 0;

        /// <summary>
        /// 注册表，高
        /// </summary>
        uint _height = 0;
        #endregion

        #region  记录读取到第几章图片的数据
        /// <summary>
        /// 记录读取到第几章图片的数据
        /// </summary>
        private int number = 0;
        #endregion

        #region  取图方式
        ///<summary>
        ///取图方式
        ///</summary>
        private Acquire acquire_Image = Acquire.Folder_Image;
        #endregion

        #region    图片的路径
        /// <summary>
        /// 图片的路径
        /// </summary>
        private List<string> path_Picture;
        #endregion

        #region   结果
        /// <summary>
        /// 结果
        /// </summary>
        [NonSerialized]
        ReadImage_Result _result = new ReadImage_Result();
        #endregion

        #region 属性
        /// <summary>
        /// 图片数据
        /// </summary>
        public HObject Ho_image
        {
            get
            {
                return ho_image;
            }

            set
            {
                ho_image = value;
            }
        }

        /// <summary>
        /// 记录读取到第几章图片的数据
        /// </summary>
        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }

        /// <summary>
        /// 图片的路径
        /// </summary>
        public List<string> Path_Picture
        {
            get
            {
                return path_Picture;
            }

            set
            {
                path_Picture = value;
            }
        }

        /// <summary>
        /// 取图方式
        /// </summary>
        public Acquire Acquire_Image
        {
            get { return acquire_Image; }
            set { acquire_Image = value; }
        }

        /// <summary>
        /// 注册表.宽
        /// </summary>
        public uint _Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// 注册表，高
        /// </summary>
        public uint _Height
        {
            get { return _height; }
            set { _height = value; }
        }

        #region  无用代码
        /// <summary>
        /// 取图方式
        /// </summary>
        //public Acquire Acquire
        //{
        //    get
        //    {
        //        return acquire;
        //    }

        //    set
        //    {
        //        acquire = value;
        //    }
        //}
        #endregion
        #endregion

        #region   初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public ReadShuJu()
        {
            path_Picture = new List<string>();
            HOperatorSet.GenEmptyObj(out ho_image);
            ho_image.Dispose();
            this.ImageFather = this;
        }
        #endregion

        #region  初始化数据变量
        /// <summary>
        /// 初始化数据变量
        /// </summary>
        public void init()
        {
            HOperatorSet.GenEmptyObj(out ho_image);
            ho_image.Dispose();
            _result = new ReadImage_Result();
            if ((_Width != 0) && (_Height != 0))
            {
                switch (Acquire_Image)
                {
                    #region 文件夹取图
                    case Acquire.Folder_Image:
                        break;
                    #endregion

                    #region  初始化注册表一
                    case Acquire.Registry_Image_One:
                        IntPtrRegistry.STRIDE_ONE = _Width;
                        IntPtrRegistry.NUMROWS_ONE = _Height;
                        break;
                    #endregion

                    #region  初始化注册表二
                    case Acquire.Registry_Image_Two:
                        IntPtrRegistry.STRIDE_TWO = _Width;
                        IntPtrRegistry.NUMROWS_TWO = _Height;
                        break;
                    #endregion
                }
            }

        }
        #endregion

        #region   保存
        /// <summary>
        /// 保存数据
        /// </summary>
        public void save()
        {

        }
        #endregion

        #region   检测
        public override bool analyze_show(HWindow hwin, string Key, ref Dictionary<string, object> _dictionary_resulte)
        {
            bool ok = false;
            try
            {
                switch (Acquire_Image)
                {
                    case Acquire.Registry_Image_One:
                        //Ho_image.Dispose();
                        ho_image.Dispose();
                        HOperatorSet.GenImage1(out ho_image, "byte", IntPtrRegistry.STRIDE_ONE, IntPtrRegistry.NUMROWS_ONE, IntPtrRegistry.Registry_Image_One);
                        //Ho_image = ho_Image;
                        _result.TolatResult = true;
                        ok = true;
                        break;

                    case Acquire.Registry_Image_Two:
                        //Ho_image.Dispose();
                        ho_image.Dispose();
                        HOperatorSet.GenImage1(out ho_image, "byte", IntPtrRegistry.STRIDE_TWO, IntPtrRegistry.NUMROWS_TWO, IntPtrRegistry.Registry_Image_Two);
                        //Ho_image = ho_Image;
                        _result.TolatResult = true;
                        ok = true;
                        break;

                    default:
                        #region   文件夹取图
                        int count = Path_Picture.Count;
                        if (Number < count)
                        {
                            //Ho_image.Dispose();
                            ho_image.Dispose();
                            HOperatorSet.ReadImage(out ho_image, Path_Picture[Number]);
                            //Ho_image.Dispose();
                            //Ho_image = ho_Image;
                            // ho_Image.Dispose();
                            Number++;
                        }
                        else
                        {
                            Number = 0;
                            //Ho_image.Dispose();
                            ho_image.Dispose();
                            HOperatorSet.ReadImage(out ho_image, Path_Picture[Number]);
                            //Ho_image = ho_Image;
                            Number++;
                        }
                        #endregion

                        _result.TolatResult = true;
                        ok = true;
                        break;
                }
                show(hwin);
            }
            catch (Exception e)
            {
                MessageBox.Show(this.ToString() + ":" + e.Message);
                _result.TolatResult = false;
                ok = false;
            }
            Key = "acquire_" + Key;
            _result.TolatName = Key;
            _dictionary_resulte.Add(Key, _result);

            return ok;
        }
        #endregion

        //#region  显示
        ///// <summary>
        ///// 显示
        ///// </summary>
        ///// <param name="hwin"></param>
        ///// <returns></returns>
        //public override bool show(HWindow hwin)
        //{
        //    bool ok = false;
        //    hwin.DispObj(this.Ho_image);
        //    return ok;
        //}
        //#endregion
    }
    #endregion

    #region 取图工具的数据接口
    /// <summary>
    /// 取图工具的数据
    /// </summary>
    public interface IReadShuJu : MultTree.IToolDateFather, IImageFather
    {
        #region 属性
        /// <summary>
        /// 图片数据
        /// </summary>
        HObject Ho_image
        {
            get
          ;
            set
          ;
        }

        /// <summary>
        /// 记录读取到第几章图片的数据
        /// </summary>
        int Number
        {
            get
        ;
            set
        ;
        }

        /// <summary>
        /// 图片的路径
        /// </summary>
        List<string> Path_Picture
        {
            get
          ;
            set
         ;
        }

        /// <summary>
        /// 取图方式
        /// </summary>
        Acquire Acquire_Image
        {
            get;
            set;
        }

        /// <summary>
        /// 注册表.宽
        /// </summary>
        uint _Width
        {
            get;
            set;
        }

        /// <summary>
        /// 注册表，高
        /// </summary>
        uint _Height
        {
            get;
            set;
        }
        #endregion

        #region  初始化数据变量
        /// <summary>
        /// 初始化数据变量
        /// </summary>
        void init();
        #endregion

        #region   保存
        /// <summary>
        /// 保存数据
        /// </summary>
        void save();
        #endregion
    }
    #endregion

    #region 取图工具的数据设置器
    /// <summary>
    /// 取图工具的数据设置器
    /// </summary>
    public class SetReadShuJu
    {
        #region  设置文件夹
        /// <summary>
        /// 把图片image写入ReadShuJu中
        /// </summary>
        /// <param name="IRead">ReadShuJu接口</param>
        /// <param name="Ho_Image">图片的数据</param>
        /// <returns></returns>
        public bool Set_Ho_Image(IReadShuJu IRead, ref HObject Ho_Image)
        {
            bool ok = false;
            IRead.Ho_image = Ho_Image;
            ok = true;
            return ok;
        }

        /// <summary>
        /// 设置去取第几张图片
        /// </summary>
        /// <param name="IRead">ReadShuJu接口</param>
        /// <param name="Num">图片的引索</param>
        /// <returns></returns>
        public bool Set_Number(IReadShuJu IRead, ref int Num)
        {
            bool ok = false;

            IRead.Number = Num;

            ok = true;
            return ok;
        }

        /// <summary>
        /// 设置图片的路径
        /// </summary>
        /// <param name="IRead">ReadShuJu接口</param>
        /// <param name="pu">图片路径</param>
        /// <returns></returns>
        public bool Set_Path_Picture(IReadShuJu IRead, ref List<string> pu)
        {
            bool ok = false;

            IRead.Path_Picture = pu;

            ok = true;
            return ok;
        }

        /// <summary>
        /// 显示参数
        /// </summary>
        /// <param name="IRead"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public bool Set_ReadShuJu_Parameter(IReadShuJu IRead, Control.ControlCollection control)
        {
            bool ok = false;

            foreach (Control con in control)
            {
                string name = con.Name;

                if ((con is ComboBox) || (con is TextBox))
                {
                    switch (name)
                    {
                        #region  取图方式
                        case "Acquire":
                            con.Text = IRead.Acquire_Image.ToString();
                            break;
                        #endregion

                        #region  注册表宽
                        case "Registry_width":

                            switch (IRead.Acquire_Image)
                            {
                                #region  初始化注册表一
                                case Acquire.Registry_Image_One:
                                    con.Text = Convert.ToString(IntPtrRegistry.STRIDE_ONE);
                                    break;
                                #endregion

                                #region  初始化注册表二
                                case Acquire.Registry_Image_Two:
                                    con.Text = Convert.ToString(IntPtrRegistry.STRIDE_TWO);
                                    break;
                                #endregion

                                #region   默认处理
                                default:
                                    break;
                                #endregion
                            }
                            break;
                        #endregion

                        #region  注册表高
                        case "Registry_height":
                            switch (IRead.Acquire_Image)
                            {
                                #region 注册表一
                                case Acquire.Registry_Image_One:
                                    con.Text = Convert.ToString(IntPtrRegistry.NUMROWS_ONE);
                                    break;
                                #endregion

                                #region 注册表二
                                case Acquire.Registry_Image_Two:
                                    con.Text = Convert.ToString(IntPtrRegistry.NUMROWS_TWO);
                                    break;
                                #endregion

                                #region  默认处理
                                default:
                                    break;
                                #endregion
                            }

                            break;
                        #endregion

                        #region  默认处理
                        default:
                            break;
                        #endregion
                    }
                }
                if (con.Controls.Count > 0)
                {
                    Set_ReadShuJu_Parameter(IRead, con.Controls);
                }
            }
            ok = true;
            return ok;
        }

        /// <summary>
        /// 设置相机取图方式
        /// </summary>
        /// <param name="IRead"></param>
        /// <param name="acquire_way"></param>
        /// <returns></returns>
        public bool Set_Acquire(IReadShuJu IRead, string acquire_way)
        {
            bool ok = false;
            switch (acquire_way)
            {
                case "Folder_Image":
                    IRead.Acquire_Image = Acquire.Folder_Image;
                    break;

                case "Registry_Image_One":
                    IRead.Acquire_Image = Acquire.Registry_Image_One;
                    break;

                case "Registry_Image_Two":
                    IRead.Acquire_Image = Acquire.Registry_Image_Two;
                    break;


                default:
                    break;
            }
            ok = true;
            return ok;
        }

        /// <summary>
        /// 设置注册表大小
        /// </summary>
        /// <param name="width_"></param>
        /// <param name="height_"></param>
        /// <returns></returns>
        public bool Set_Registry(IReadShuJu IRead, string width_, string height_)
        {
            bool ok = false;

            switch (IRead.Acquire_Image)
            {
                #region  文件夹
                case Acquire.Folder_Image:
                    MessageBox.Show("当前为文件夹取图，设置注册表大小失败");
                    ok = false;
                    break;
                #endregion

                #region   注册表一
                case Acquire.Registry_Image_One:
                    IRead._Width = Convert.ToUInt32(width_);
                    IRead._Height = Convert.ToUInt32(height_);

                    IntPtrRegistry.STRIDE_ONE = Convert.ToUInt32(width_);
                    IntPtrRegistry.NUMROWS_ONE = Convert.ToUInt32(height_);
                    ok = true;
                    break;
                #endregion

                #region  注册表二
                case Acquire.Registry_Image_Two:
                    IRead._Width = Convert.ToUInt32(width_);
                    IRead._Height = Convert.ToUInt32(height_);

                    IntPtrRegistry.STRIDE_TWO = Convert.ToUInt32(width_);
                    IntPtrRegistry.NUMROWS_TWO = Convert.ToUInt32(height_);
                    ok = true;
                    break;
                #endregion

                #region  默认处理
                default:
                    ok = false;
                    break;
                #endregion
            }
            return ok;
        }

        #endregion
    }
    #endregion

    //#region   取图工具数据分析器
    ///// <summary>
    ///// 取图工具数据分析器
    ///// </summary>
    //public class ReadImage : IReadImage
    //{
    //    #region   全局变量
    //    /// <summary>
    //    /// 图片缓存
    //    /// </summary>
    //    HObject ho_Image;
    //    #endregion

    //    #region   初始化数据
    //    /// <summary>
    //    /// 初始化数据
    //    /// </summary>
    //    public ReadImage()
    //    {
    //        HOperatorSet.GenEmptyObj(out ho_Image);
    //    }
    //    #endregion

    //    #region  获取图片
    //    /// <summary>
    //    /// 获取图片
    //    /// </summary>
    //    /// <param name="IRead">图片数据</param>
    //    /// <returns></returns>
    //    public bool read_Image(IReadShuJu IRead)
    //    {
    //        bool ok = false;
    //        try
    //        {
    //            switch (IRead.Acquire_Image)
    //            {
    //                case Acquire.Registry_Image_One:
    //                    IRead.Ho_image.Dispose();
    //                    ho_Image.Dispose();
    //                    HOperatorSet.GenImage1(out ho_Image, "byte", IntPtrRegistry.STRIDE_ONE, IntPtrRegistry.NUMROWS_ONE, IntPtrRegistry.Registry_Image_One);
    //                    IRead.Ho_image = ho_Image;
    //                    break;

    //                case Acquire.Registry_Image_Two:
    //                    IRead.Ho_image.Dispose();
    //                    ho_Image.Dispose();
    //                    HOperatorSet.GenImage1(out ho_Image, "byte", IntPtrRegistry.STRIDE_TWO, IntPtrRegistry.NUMROWS_TWO, IntPtrRegistry.Registry_Image_Two);
    //                    IRead.Ho_image = ho_Image;
    //                    break;

    //                default:
    //                    #region   文件夹取图
    //                    int count = IRead.Path_Picture.Count;
    //                    if (IRead.Number < count)
    //                    {
    //                        IRead.Ho_image.Dispose();
    //                        ho_Image.Dispose();
    //                        HOperatorSet.ReadImage(out ho_Image, IRead.Path_Picture[IRead.Number]);
    //                        IRead.Ho_image.Dispose();
    //                        IRead.Ho_image = ho_Image;
    //                        // ho_Image.Dispose();
    //                        IRead.Number++;
    //                    }
    //                    else
    //                    {
    //                        IRead.Number = 0;
    //                        //IRead.Ho_image.Dispose();
    //                        // ho_Image.Dispose();

    //                        HOperatorSet.ReadImage(out ho_Image, IRead.Path_Picture[IRead.Number]);
    //                        IRead.Ho_image = ho_Image;

    //                        IRead.Number++;
    //                    }
    //                    #endregion
    //                    break;
    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            MessageBox.Show(this.ToString() + ":" + e.Message);

    //        }

    //        ok = true;
    //        return ok;
    //    }
    //    #endregion

    //    #region    显示  保存
    //    /// <summary>
    //    /// 读取  显示  保存
    //    /// </summary>
    //    /// <param name="IRead"></param>
    //    /// <param name="Key"></param>
    //    /// <param name="_dictionary_resulte"></param>
    //    /// <returns></returns>
    //    public bool read_Image1(IReadShuJu IRead, string Key, ref Dictionary<string, Object> _dictionary_resulte)
    //    {
    //        bool ok = false;
    //        ReadImage_Result _readImage_Result = new ReadImage_Result();

    //        try
    //        {
    //            switch (IRead.Acquire_Image)
    //            {
    //                case Acquire.Registry_Image_One:
    //                    IRead.Ho_image.Dispose();
    //                    ho_Image.Dispose();
    //                    HOperatorSet.GenImage1(out ho_Image, "byte", IntPtrRegistry.STRIDE_ONE, IntPtrRegistry.NUMROWS_ONE, IntPtrRegistry.Registry_Image_One);
    //                    IRead.Ho_image = ho_Image;

    //                    _readImage_Result.TolatResult = true;
    //                    ok = true;
    //                    break;

    //                case Acquire.Registry_Image_Two:
    //                    IRead.Ho_image.Dispose();
    //                    ho_Image.Dispose();
    //                    HOperatorSet.GenImage1(out ho_Image, "byte", IntPtrRegistry.STRIDE_TWO, IntPtrRegistry.NUMROWS_TWO, IntPtrRegistry.Registry_Image_Two);
    //                    IRead.Ho_image = ho_Image;

    //                    _readImage_Result.TolatResult = true;
    //                    ok = true;
    //                    break;

    //                default:
    //                    #region   文件夹取图
    //                    int count = IRead.Path_Picture.Count;
    //                    if (IRead.Number < count)
    //                    {
    //                        IRead.Ho_image.Dispose();
    //                        ho_Image.Dispose();
    //                        HOperatorSet.ReadImage(out ho_Image, IRead.Path_Picture[IRead.Number]);
    //                        IRead.Ho_image.Dispose();
    //                        IRead.Ho_image = ho_Image;
    //                        // ho_Image.Dispose();
    //                        IRead.Number++;
    //                    }
    //                    else
    //                    {
    //                        IRead.Number = 0;
    //                        IRead.Ho_image.Dispose();
    //                        ho_Image.Dispose();

    //                        HOperatorSet.ReadImage(out ho_Image, IRead.Path_Picture[IRead.Number]);
    //                        IRead.Ho_image = ho_Image;

    //                        IRead.Number++;
    //                    }
    //                    #endregion

    //                    _readImage_Result.TolatResult = true;
    //                    ok = true;
    //                    break;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            MessageBox.Show(this.ToString() + ":" + e.Message);
    //            _readImage_Result.TolatResult = false;
    //            ok = false;
    //        }
    //        Key = "acquire_" + Key;
    //        _readImage_Result.TolatName = Key;
    //        _dictionary_resulte.Add(Key, _readImage_Result);
    //        return ok;
    //    }
    //    #endregion

    //    #region   显示数据
    //    /// <summary>
    //    /// 显示数据
    //    /// </summary>
    //    /// <param name="IRead">数据接口</param>
    //    /// <param name="hwin">要显示的窗口</param>
    //    /// <returns></returns>
    //    public bool show_Image(IReadShuJu IRead, HWindow hwin)
    //    {
    //        bool ok = false;

    //        hwin.DispObj(IRead.Ho_image);

    //        ok = true;
    //        return ok;
    //    }
    //    #endregion

    //    #region  读取 显示
    //    /// <summary>
    //    ///  读取 显示
    //    /// </summary>
    //    /// <param name="IRead"></param>
    //    /// <param name="hwin"></param>
    //    public bool Read_Show(IReadShuJu IRead, HWindow hwin)
    //    {
    //        bool ok = false;
    //        try
    //        {
    //            read_Image(IRead);
    //            hwin.DispObj(IRead.Ho_image);
    //            ok = true;
    //        }
    //        catch (Exception e)
    //        {
    //            MessageBox.Show(this.ToString() + ":" + e.Message);
    //        }
    //        return ok;
    //    }
    //    #endregion
    //}
    //#endregion

    //#region  取图工具数据分析器接口
    ///// <summary>
    ///// 取图工具数据分析器接口
    ///// </summary>
    //public interface IReadImage
    //{
    //    #region  取图工具
    //    /// <summary>
    //    ///取图工具
    //    /// </summary>
    //    /// <param name="IRead"></param>
    //    /// <returns></returns>
    //    bool read_Image(IReadShuJu IRead);
    //    #endregion
    //}
    //#endregion

    #region   取图的结果
    /// <summary>
    /// 取图的结果
    /// </summary>
    public class ReadImage_Result : MultTree.ClassResultFather
    {
        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public override bool showResult(out string str)
        {
            bool ok = false;

            str = this.TolatName + ":" + this.TolatResult.ToString();

            ok = true;
            return ok;
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="str_array"></param>
        /// <returns></returns>
        public override bool showResult(out string[] str_array)
        {

            bool ok = false;
            str_array = new string[2];
            str_array[0] = this.TolatName;
            str_array[1] = this.TolatResult.ToString();
            ok = true;
            return ok;

        }
    }

    #endregion

    #region    图片的父类
    /// <summary>
    /// 图片父类
    /// </summary>
    [Serializable]
    public class ImageFather : IImageFather
    {
        #region   全局变量
        /// <summary>
        /// 图片缓存
        /// </summary>
        [NonSerialized]
        HObject ho_Image;
        #endregion

        #region  属性
        /// <summary>
        /// 图片缓存
        /// </summary>
        public HObject Ho_image
        {
            get { return ho_Image; }
            set { ho_Image = value; }
        }
        #endregion
    }

    /// <summary>
    /// 父类图片接口
    /// </summary>
    public interface IImageFather
    {
        #region  属性
        /// <summary>
        /// 图片缓存
        /// </summary>
        HObject Ho_image
        {
            get;
            set;
        }
        #endregion
    }

    /// <summary>
    /// 父类图片接口  ,对外
    /// </summary>
    public interface IImageFatherOutSide
    {
        /// <summary>
        /// 父类图片接口
        /// </summary>
        IImageFather ImageFather
        {
            get;
            set;
        }
    }
    #endregion

    #region   无用代码
    #region   文件夹取图驱动

    //#region   文件夹驱动数据
    ///// <summary>
    ///// 文件夹取图的数据
    ///// </summary>
    //public class Folder_Drive: IFolder_Drive
    //{
    //    #region  记录读取到第几章图片的数据  
    //    /// <summary>
    //    /// 记录读取到第几章图片的数据
    //    /// </summary>
    //    private int number = 0;
    //    #endregion

    //    #region    图片的路径        
    //    /// <summary>
    //    /// 图片的路径
    //    /// </summary>
    //    private List<string> path_Picture;
    //    #endregion

    //    #region  属性
    //    #region   记录读取到第几章图片的数据
    //    /// <summary>
    //    /// 记录读取到第几章图片的数据
    //    /// </summary>
    //    public int Number
    //    {
    //        get
    //        {
    //            return number;
    //        }
    //        set
    //        {
    //            number = value;
    //        }
    //    }
    //    #endregion


    //    #region   图片路径
    //    /// <summary>
    //    /// 图片路径
    //    /// </summary>
    //    public List<string> Path_Picture
    //    {
    //        get
    //        {
    //            return path_Picture;
    //        }

    //        set
    //        {
    //            path_Picture = value;
    //        }
    //    }
    //    #endregion

    //    #endregion

    //}
    //#endregion

    //#region  文件接口
    ///// <summary>
    ///// 文件接口
    ///// </summary>
    //public interface IFolder_Drive
    //{
    //    #region  属性

    //    #region   记录读取到第几章图片的数据
    //    /// <summary>
    //    /// 记录读取到第几章图片的数据
    //    /// </summary>
    //     int Number
    //    {
    //        get
    //       ;
    //        set
    //       ;
    //    }
    //    #endregion

    //    #region   图片路径
    //    /// <summary>
    //    /// 图片路径
    //    /// </summary>
    //     List<string> Path_Picture
    //    {
    //        get
    //       ;
    //        set
    //       ;
    //    }
    //    #endregion

    //    #endregion
    //}
    //#endregion

    //#region  文件夹取图工具
    ///// <summary>
    ///// 文件夹取图工具
    ///// </summary>
    //public class Acquire_Folder
    //{
    //    #region   全局变量
    //    /// <summary>
    //    /// 图片缓存
    //    /// </summary>
    //    HObject ho_Image;
    //    #endregion

    //    #region   初始化数据
    //    /// <summary>
    //    /// 初始化数据
    //    /// </summary>
    //    public Acquire_Folder()
    //    {
    //        HOperatorSet.GenEmptyObj(out ho_Image);
    //    }
    //    #endregion

    //    #region   取图工具
    //    /// <summary>
    //    /// 取图工具
    //    /// </summary>
    //    /// <param name="IRead"></param>
    //    /// <returns></returns>
    //    public bool Acquire_Folder_Image(IReadShuJu IRead)
    //    {
    //        bool ok = false;
    //        try
    //        {
    //            int count = IRead.Path_Picture.Count;
    //            if (IRead.Number < count)
    //            {
    //                IRead.Ho_image.Dispose();
    //                ho_Image.Dispose();
    //                HOperatorSet.ReadImage(out ho_Image, IRead.Path_Picture[IRead.Number]);
    //                // IRead.Ho_image.Dispose();
    //                IRead.Ho_image = ho_Image;
    //                // ho_Image.Dispose();
    //                IRead.Number++;
    //            }
    //            else
    //            {
    //                IRead.Number = 0;
    //                IRead.Ho_image.Dispose();
    //                ho_Image.Dispose();

    //                HOperatorSet.ReadImage(out ho_Image, IRead.Path_Picture[IRead.Number]);
    //                IRead.Ho_image = ho_Image;

    //                IRead.Number++;
    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            MessageBox.Show(this.ToString() + ":" + e.Message);

    //        }

    //        ok = true;
    //        return ok;
    //    }
    //    #endregion
    //}
    //#endregion

    #endregion
    #endregion
}
