using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace Point.Pull
{
    public class Program
    {
        private static readonly long adzone_id = 509420499L;
        private static readonly string url = "http://gw.api.taobao.com/router/rest";
        private static readonly string appkey = "24877336";
        private static readonly string appsecret = "a8f92c1228e38051d8457cc56d7158f7";

        public static void Main(string[] args)
        {
            Program p = new Program();
            p.Pull_taobao_tbk_get();
        }


        /// <summary>
        /// 好券清单API【导购】
        /// http://open.taobao.com/docs/api.htm?spm=a219a.7629065.0.0.7LescP&apiId=29821
        /// </summary>
        public void Pull_taobao_tbk_get()
        {
            Console.WriteLine("请输入操作类型（1 好券清单；2 后台类目）：");

            var strType = Console.ReadLine();
            if (strType == "1")
            {
                try
                {
                    while (true)
                    {
                        #region 好券清单API

                        Console.WriteLine("请输入查询关键字：");
                        var strKey = Console.ReadLine();

                        Console.WriteLine("请输入查询分类ID，多个用 , 分割，回车之后开始拉取：");
                        var strCateIds = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(strKey))
                        {
                            while (string.IsNullOrWhiteSpace(strCateIds))
                            {
                                Console.WriteLine("请输入查询分类ID，多个用 , 分割，回车之后开始拉取：");
                                strCateIds = Console.ReadLine();
                            }
                        }

                        List<Taobao_tbk_dg_item_coupon_get> tbkCouponList = new List<Taobao_tbk_dg_item_coupon_get>();
                        DateTime dtNow = DateTime.Now;

                        #region

                        Console.WriteLine("开始拉取...");

                        ITopClient client = new DefaultTopClient(url, appkey, appsecret);
                        TbkDgItemCouponGetRequest req = new TbkDgItemCouponGetRequest();
                        req.AdzoneId = adzone_id;
                        req.PageNo = 1;
                        req.PageSize = 100;
                        req.Q = strKey;
                        req.Cat = strCateIds;
                        req.Platform = 2;

                        TbkDgItemCouponGetResponse response = client.Execute(req);
                        if (response != null && response.Results != null && response.Results.Count > 0)
                        {
                            foreach (var res in response.Results)
                            {
                                #region

                                Taobao_tbk_dg_item_coupon_get tbk = new Taobao_tbk_dg_item_coupon_get();
                                tbk.Shop_title = res.ShopTitle;
                                tbk.User_type = Convert.ToInt32(res.UserType);
                                tbk.Zk_final_price = res.ZkFinalPrice;
                                tbk.Title = res.Title;
                                tbk.Nick = res.Nick;
                                tbk.Seller_id = res.SellerId;
                                tbk.Volume = res.Volume;
                                tbk.Pict_url = res.PictUrl;
                                tbk.Item_url = res.ItemUrl;
                                tbk.Coupon_total_count = res.CouponTotalCount;
                                tbk.Commission_rate = res.CommissionRate;
                                tbk.Coupon_info = res.CouponInfo;
                                tbk.Category = Convert.ToInt32(res.Category);
                                tbk.Num_iid = res.NumIid;
                                tbk.Coupon_remain_count = res.CouponRemainCount;
                                tbk.Coupon_start_time = res.CouponStartTime;
                                tbk.Coupon_end_time = res.CouponEndTime;
                                tbk.Coupon_click_url = res.CouponClickUrl;
                                tbk.Item_description = res.ItemDescription;
                                //tbk.Small_images = res.SmallImages;
                                tbk.RowCreateTime = dtNow;
                                tbk.IsHandle = false;

                                #endregion

                                tbkCouponList.Add(tbk);
                            }

                            //Console.WriteLine("防止API频率限制，休眠 100 ms ....");
                            //Thread.Sleep(100);
                            Console.WriteLine(string.Format("结束拉取...成功拉取 {0} 条数据", response.Results.Count));
                        }
                        else
                        {
                            Console.WriteLine(" API 未能返回数据，退出本次拉取...");
                        }

                        #endregion

                        if (tbkCouponList.Count > 0)
                        {
                            //落地数据库
                            Console.WriteLine("开始落地数据库，时间稍长......");
                            using (PointDataDataContext pd = new PointDataDataContext())
                            {
                                pd.Taobao_tbk_dg_item_coupon_get.InsertAllOnSubmit(tbkCouponList);
                                pd.SubmitChanges();
                            }
                            Console.WriteLine("结束落地数据库......");
                        }

                        Console.WriteLine(string.Format("成功拉取 好券清单API【导购】......本次共拉取 {0} 条数据", tbkCouponList.Count));

                        Console.WriteLine("");
                        Console.WriteLine("*****************************************************************");
                        Console.WriteLine("");

                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("拉取 好券清单API【导购】 异常：" + ex.ToString());
                }
            }
            else
            {
                try
                {
                    Console.WriteLine("开始拉取后台类目...");




                    Console.WriteLine(string.Format("成功拉取后台类目......本次共拉取 {0} 条数据", 12));

                    Console.WriteLine("");
                    Console.WriteLine("*****************************************************************");
                    Console.WriteLine("");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("拉取 后台类目 异常：" + ex.ToString());
                }
            }
        }
    }
}
