using System.Web.Http;
using WebApplication1.DTO;
using SignIn;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;


namespace WebApplication1.Controllers
{
    public class InsertPriceQuotesController : ApiController
    {
        
        igroup195_DB_Prod db = new igroup195_DB_Prod();

        [HttpPost]
        [Route("api/InsertPriceQuote")]
        public IHttpActionResult InsertPriceQuote([FromBody] PriceDTO priceDTO)
        {

            try 
            {
                if (priceDTO.Customer_PK == 0 ||
                    priceDTO.Project_Id == 0 ||
                    priceDTO.TotalWork_Hours == 0 ||
                    priceDTO.Total_Price == 0)
                {
                    return BadRequest("One or more parameters are missing or empty");
                }

               
                PriceQuotes newPriceQuote = new PriceQuotes()                 {
                    CustomerPK = priceDTO.Customer_PK,
                    ProjectID = priceDTO.Project_Id,
                    TotalWorkHours = priceDTO.TotalWork_Hours,
                    DiscoutPercent = priceDTO.Discout_Percent,
                    TotalPrice = priceDTO.Total_Price,
                    PriceQuoteFile = priceDTO.PriceQuote_File
                };

                db.PriceQuotes.Add(newPriceQuote);

                return Ok("Price Quote details saved successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error saving Price Quote details: {ex.Message}");
            }
        }

    }
}
