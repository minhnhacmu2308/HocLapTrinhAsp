using HocLapTrinhAspNet.Models;
using HocLapTrinhAspNet.Repositorys;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HocLapTrinhAspNet.Controllers
{
    public class CourseController : Controller
    {
        UserRepository _userRepository = new UserRepository();
        CourseRepository courseRepository = new CourseRepository();
        CourseTypeRepository courseTypeRepository = new CourseTypeRepository();
        OrderRepository orderRepository = new OrderRepository();
        // GET: Course
        public ActionResult Index(string isFree,int page)
        {
            if (page == 0)
            {
                page = 1;
            }
            ViewBag.courses = courseRepository.GetCourseByIsFree(bool.Parse(isFree), page, 6);
            ViewBag.tag = page;
            ViewBag.pageSize = courseRepository.getNumberByIsFree(bool.Parse(isFree));
            ViewBag.isFree = isFree;
            return View();
        }

        public ActionResult Detail(int id,string mess)
        {
            ViewBag.course = courseRepository.GetCourseById(id);
            ViewBag.mess = mess;
            return View();
        }

        public ActionResult CourseAll(int page)
        {
            if (page == 0)
            {
                page = 1;
            }
            ViewBag.courses = courseRepository.Gets(page, 6);
            ViewBag.tag = page;
            ViewBag.pageSize = courseRepository.getNumber();
            return View();
        }

        public ActionResult GetCourseByType(int courseTypeId, int page)
        {
            if (page == 0)
            {
                page = 1;
            }
            var list = courseRepository.GetCourseByType(courseTypeId, page, 6);
            var obj = courseTypeRepository.GetCourseTypeById(courseTypeId);
            ViewBag.courses = list;
            ViewBag.tag = page;
            ViewBag.pageSize = courseRepository.getNumberByType(courseTypeId);
            ViewBag.Type = obj;
            return View();
        }

        [HttpPost]
        public ActionResult SearchCourse(string keySearch)
        {
            return RedirectToAction("SearchCourse", "Course", new { keySearch = keySearch, page = 0 });
        }


        public ActionResult SearchCourse(string keySearch, int page)
        {
            if (page == 0)
            {
                page = 1;
            }
            var list = courseRepository.SearchCourse(keySearch, page, 6);
            ViewBag.courses = list;
            ViewBag.tag = page;
            ViewBag.pageSize = courseRepository.getNumberBySearch(keySearch);
            ViewBag.Type = keySearch;
            return View();
        }

        public ActionResult PaymentMoMo(int courseId)
        {
            var obj = courseRepository.GetCourseById(courseId);
            int total = Convert.ToInt32(obj.Price);
            string url = "https://localhost:44359/Course/ReturnUrl/" + courseId;
            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOOJOI20210710";
            string accessKey = "iPXneGmrJH0G8FOP";
            string serectkey = "sFcbSGRSJjwGxwhhcEktCHWYUuTuPNDB";
            string orderInfo = "Thanh toán momo tại web";
            string returnUrl = url;
            string notifyurl = "http://ba1adf48beba.ngrok.io/Home/SavePayment"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

            string amount = total.ToString();
            string orderid = DateTime.Now.Ticks.ToString();
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            //sign signature SHA256
            string signature = signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

            string responseFromMomo = sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);


            return Redirect(jmessage.GetValue("payUrl").ToString());
        }

        public ActionResult ReturnUrl(int id)
        {
            User user = (User)Session["USER"];
            orderRepository.AddOrder(new Order
            {
                UserId = user.UserId,
                CourseId = id,
                OrderDate = DateTime.Now
            });
            return RedirectToAction("Detail","Course", new { id = id, mess = "2" });
        }

        //Khi thanh toán xong ở cổng thanh toán Momo, Momo sẽ trả về một số thông tin, trong đó có errorCode để check thông tin thanh toán
        //errorCode = 0 : thanh toán thành công (Request.QueryString["errorCode"])
        //Tham khảo bảng mã lỗi tại: https://developers.momo.vn/#/docs/aio/?id=b%e1%ba%a3ng-m%c3%a3-l%e1%bb%97i
        public ActionResult ConfirmPaymentClient()
        {
            //hiển thị thông báo cho người dùng
            return View();
        }

        [HttpPost]
        public void SavePayment()
        {
            //cập nhật dữ liệu vào db
        }
        public string getHash(string partnerCode, string merchantRefId,
          string amount, string paymentCode, string storeId, string storeName, string publicKeyXML)
        {
            string json = "{\"partnerCode\":\"" +
                partnerCode + "\",\"partnerRefId\":\"" +
                merchantRefId + "\",\"amount\":" +
                amount + ",\"paymentCode\":\"" +
                paymentCode + "\",\"storeId\":\"" +
                storeId + "\",\"storeName\":\"" +
                storeName + "\"}";

            byte[] data = Encoding.UTF8.GetBytes(json);
            string result = null;
            using (var rsa = new RSACryptoServiceProvider(4096)) //KeySize
            {
                try
                {
                    // MoMo's public key has format PEM.
                    // You must convert it to XML format. Recommend tool: https://superdry.apphb.com/tools/online-rsa-key-converter
                    rsa.FromXmlString(publicKeyXML);
                    var encryptedData = rsa.Encrypt(data, false);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    result = base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }

            }

            return result;

        }
        public string buildQueryHash(string partnerCode, string merchantRefId,
            string requestid, string publicKey)
        {
            string json = "{\"partnerCode\":\"" +
                partnerCode + "\",\"partnerRefId\":\"" +
                merchantRefId + "\",\"requestId\":\"" +
                requestid + "\"}";

            byte[] data = Encoding.UTF8.GetBytes(json);
            string result = null;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    // client encrypting data with public key issued by server
                    rsa.FromXmlString(publicKey);
                    var encryptedData = rsa.Encrypt(data, false);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    result = base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }

            }

            return result;

        }

        public string buildRefundHash(string partnerCode, string merchantRefId,
            string momoTranId, long amount, string description, string publicKey)
        {
            string json = "{\"partnerCode\":\"" +
                partnerCode + "\",\"partnerRefId\":\"" +
                merchantRefId + "\",\"momoTransId\":\"" +
                momoTranId + "\",\"amount\":" +
                amount + ",\"description\":\"" +
                description + "\"}";

            byte[] data = Encoding.UTF8.GetBytes(json);
            string result = null;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    // client encrypting data with public key issued by server
                    rsa.FromXmlString(publicKey);
                    var encryptedData = rsa.Encrypt(data, false);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    result = base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }

            }

            return result;

        }
        public string signSHA256(string message, string key)
        {
            byte[] keyByte = Encoding.UTF8.GetBytes(key);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                string hex = BitConverter.ToString(hashmessage);
                hex = hex.Replace("-", "").ToLower();
                return hex;

            }
        }

        public static string sendPaymentRequest(string endpoint, string postJsonString)
        {

            try
            {
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(endpoint);

                var postData = postJsonString;

                var data = Encoding.UTF8.GetBytes(postData);

                httpWReq.ProtocolVersion = HttpVersion.Version11;
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/json";

                httpWReq.ContentLength = data.Length;
                httpWReq.ReadWriteTimeout = 30000;
                httpWReq.Timeout = 15000;
                Stream stream = httpWReq.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();

                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();

                string jsonresponse = "";

                using (var reader = new StreamReader(response.GetResponseStream()))
                {

                    string temp = null;
                    while ((temp = reader.ReadLine()) != null)
                    {
                        jsonresponse += temp;
                    }
                }


                //todo parse it
                return jsonresponse;
                //return new MomoResponse(mtid, jsonresponse);

            }
            catch (WebException e)
            {
                return e.Message;
            }
        }
    }
}