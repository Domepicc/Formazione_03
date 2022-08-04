using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tools_WebApp.Queries;
using Tools_WebApp.Models;
using Tools_WebApp.Commands;
using System.Web.Http;
using Autofac;
using Tools_WebApp.App_Start;
using Newtonsoft.Json;
using System.IO;

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

        public ActionResult GetById(string id)
        {
            return Json(_query.ReadById(id), JsonRequestBehavior.AllowGet);
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
            CreateToolCommand command = new CreateToolCommand(model);

            // osserva come dopo il publish il controllo passa a UpdateToolQuantityCommandHandler senza bisogno di chiamarlo direttamente

            // anche _commandBus viene istanziato da Autofac

            _command.Publish(command);

            return true;

        }

        [System.Web.Http.Route("api/Tools/{id}/ChangeQuantity")]
        public bool PostToolQuantity([FromBody] Tool model)
        {
            UpdateToolQuantityCommand command = new UpdateToolQuantityCommand(model.IdTool, model.Quantity);

            // osserva come dopo il publish il controllo passa a UpdateToolQuantityCommandHandler senza bisogno di chiamarlo direttamente

            // anche _commandBus viene istanziato da Autofac

            _command.Publish(command);

            return true;
        }


        public ActionResult Tools()
        {
            return View();
        }
    }
}