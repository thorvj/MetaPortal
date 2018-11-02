using Microsoft.AspNetCore.Mvc;

namespace MetaPortal.Controllers
{
    //about 

    [Route("[controller]/[action]")]
    public class AboutController
    {        
        public string Phone()
        {
            return "555-3000";
        }
        
        public string Address()
        {
            return "Bankastræti 5";
        }
    }
}