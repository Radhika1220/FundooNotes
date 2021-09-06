using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class LabelController : ControllerBase
    {
        private readonly ILabelManager labelManager;

        public LabelController(ILabelManager labelManager)
        {
            this.labelManager = labelManager;
        }
        [HttpPost]
        [Route("api/CreateLabel")]
        public IActionResult CreateLabel([FromBody] LabelModel labelModel)
        {
            try
            {
                string message = this.labelManager.CreateLabel(labelModel);
                if (message.Equals("Created Label Successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = message });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = message });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/AddLabel")]
        public IActionResult AddLabel([FromBody] LabelModel labelModel)
        {
            try
            {
                string message = this.labelManager.AddLabel(labelModel);
                if (message.Equals("Label added successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = message });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = message });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }



        [HttpDelete]
        [Route("api/RemoveLabelInNotes")]
        public IActionResult RemoveLabelInNotes(int labelId)
        {
            try
            {
                string message = this.labelManager.RemoveLabelInNotes(labelId);
                if (message.Equals("Label removed successfully in notes"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = message });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = message });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }


        [HttpDelete]
        [Route("api/DeleteLabel")]
        public IActionResult DeleteLabel(string labelName, int userId)
        {
            try
            {
                string message = this.labelManager.DeleteLabel(labelName, userId);
                if (message.Equals("Deleted Label Successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = message });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = message });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/GetAllLabels")]
        public IActionResult GetAllLabels(int userId)
        {
            try
            {
                var resMessage = this.labelManager.GetAllLabels(userId);
                if (resMessage != null)
                {
                    return this.Ok(new { Status = true, Message = "Label returned successfully", Data = resMessage });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "label does not exist" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/GetLabelByNotes")]
        public IActionResult GetLabelByNotes(int noteId,int userId)
        {
            try
            {
                var resMessage = this.labelManager.GetLabelByNotes(noteId,userId);
                if (resMessage != null)
                {
                    return this.Ok(new { Status = true, Message = "Label returned successfully", Data = resMessage });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "label does not exist" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }


        }
    }
}
