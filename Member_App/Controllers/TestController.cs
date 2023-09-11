using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Member_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet("Test")]
        public JsonResult Test1()
        {
            //Variable
            Int32 number = 123;
            double grad = 4.00;
            bool TF = false;
            string value = "Name";
            DateTime today = DateTime.Now;

            // Array
            string[] arr1 = {"A", "B", "C", "D"};
            string C = arr1[2].ToString();

            int[] arr2 = { 1, 2, 3 };
            int A = arr2[0];
            int count = arr2.Count();

            // Object Model
            TestModel data = new TestModel();
            data.Id = number;
            data.Productname = "Iphone";
            data.QTY = 300;
            data.price = 39900.00;
            data.expire = Convert.ToDateTime("11/09/2566");
            data.active = true;


            //Loop
            int N = 5;
            int[] arrs = new int[N];
            int total = 0;
            for (int i = 1; i <= N; i++) 
            {
                total = i;
                arrs[i - 1] = i;
            }


            return Json(data);
        }
    }
    public class TestModel 
    {
        public int Id { get; set; }
        public string Productname { get; set; }
        public int QTY { get; set; }
        public double price { get; set; }
        public DateTime expire { get; set; }
        public bool active { get; set; }
    }
}

