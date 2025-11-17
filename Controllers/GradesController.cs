using GradeMaster_API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace GradeMaster_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Calculate([FromBody] GradeRequest newGrade)
        {
            if (newGrade is null)
                return BadRequest();

            var newAverage = (newGrade.MidtermWeight * newGrade.Midterm) + (newGrade.FinalWeight * newGrade.Final);

            var response = new GradeResponse();

            if (newAverage >= newGrade.PassingGrade)
            {
                response.Status = true;
                response.Average = newAverage;
                response.Comment = "You passed the course. Congratulations.";
                response.RequiredFinal = 0;
            }
                


            else if (newAverage < newGrade.PassingGrade)
            {
                response.Status = false;
                response.Average = newAverage;
                response.RequiredFinal = Math.Round(
                    (newGrade.PassingGrade - newGrade.Midterm * newGrade.MidtermWeight) / newGrade.FinalWeight, 2);

                response.Comment = $"You failed the course. You needed to score {response.RequiredFinal} on the final exam.";              
            }

            return Ok(response);
        }

    }
}
