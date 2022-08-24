using System;
using System.Web.Http;
using System.Web.Mvc;
using Tools_WebApp.Commands;
using Tools_WebApp.Models;
using Tools_WebApp.Queries;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace Tools_WebApp.Controllers
{
    public class ToolsController : Controller
    {

        private readonly IQuery<Tool> _query;
        private readonly ICommandPost _command;

        public ToolsController(IQuery<Tool> query, ICommandPost command)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            _query = query;
            _command = command;
        }


        public ActionResult Get()
        {
            return PartialView("_Tools", _query.ReadAll());
        }

        [System.Web.Mvc.Route("Tools/{id}/Details")]
        public ActionResult GetById(string id)
        {
            return View("ToolDetails", _query.ReadById(id));
        }

        //public ActionResult GetByPartialId(string id)
        //{
        //    // need to return a partial view 
        //    return Json(_query.ReadByPartialId(id), JsonRequestBehavior.AllowGet);
        //}

        public ActionResult GetByPartialId(string id)
        {
            // need to return a partial view 
            return PartialView("_Tools", _query.ReadByPartialId(id));
        }

        public bool Delete(string id)
        {
            DeleteToolCommand command = new DeleteToolCommand(id);

            _command.Publish(command);

            return true;
        }

        public bool Post([FromBody] Tool model)
        {
            if (ModelState.IsValid)
            {
                CreateToolCommand command = new CreateToolCommand(model);

                // osserva come dopo il publish il controllo passa a UpdateToolQuantityCommandHandler senza bisogno di chiamarlo direttamente

                // anche _commandBus viene istanziato da Autofac

                _command.Publish(command);
            }
        

 

            return true;

        }

        [System.Web.Mvc.Route("api/Tools/{id}/ChangeQuantity")]
        public bool PostToolQuantity([FromBody] Tool model)
        {
            UpdateToolQuantityCommand command = new UpdateToolQuantityCommand(model.IdTool, model.Quantity);

            // osserva come dopo il publish il controllo passa a UpdateToolQuantityCommandHandler senza bisogno di chiamarlo direttamente

            // anche _commandBus viene istanziato da Autofac

            _command.Publish(command);

            return true;
        }


        public ActionResult Index()
        {
            return View();
        }
    }
}