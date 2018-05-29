using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicJournal.Domain.Abstract;
using ElectronicJournal.WebUI.Models;

namespace ElectronicJournal.WebUI.Controllers
{
    public class AdminController : Controller
    {
        IPrepodRepository prepodRepository;
        ITroopRepository troopRepository;
        IDisciplineRepository disciplineRepository;
        public AdminController(IPrepodRepository prepod, ITroopRepository troop, IDisciplineRepository discipline)
        {
            prepodRepository = prepod;
            troopRepository = troop;
            disciplineRepository = discipline;
        }
        // GET: Admin
        public JsonResult GetJsonMenu(int PrepodId,int? ParentId = null)
        {
            PersonalArealViewModel model = new PersonalArealViewModel();
            model.Prepod = prepodRepository.Prepods.Where(ob => ob.PrepodId == PrepodId).FirstOrDefault();
            if (model.Prepod == null)
            {
                throw new Exception("В личный кабинет не передан Id Препода");
            }
            foreach (var item in troopRepository.troops) // TODO немного не то, подумать как переделать, сейчас мы проходим по всем взводам и выбираем из них только нужные нам, создавая копию взвода и кладем теда только нужные темы
            {
                if (item.Disciplines.FindAll(ob => ob.PrepodId == model.Prepod.PrepodId).Count != 0)
                {
                    model.Troops.Add(item.CreateNewTroopOnliDisciplinesOnPrepod(model.Prepod.PrepodId));
                }
            }

            //if (ParentId == null)
            //{
                return Json(model.Troops.Select(p => new
                {
                    id = p.TroopId.ToString(), // 't' добавлено для того чтобы Ид были уникальными
                    parent = "#",
                    text = p.Number,
                    state = new 
                    {
                        disabled = false
                    },
                    children = false
                }), JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    string Parent = ParentId.Substring(1);
            //    return Json(model.Troops.Find(ob=>ob.TroopId.ToString() == Parent).Disciplines.Select(p => new
            //    {
            //        id = p.DisciplineId.ToString(),
            //        parent = ParentId.ToString(),
            //        text = p.Name,
            //        children = false,
            //    }), JsonRequestBehavior.AllowGet);
            //}
        }
        public JsonResult GetJsonDiscipline(int TroopId, int PrepodId)
        {
            PersonalArealViewModel model = new PersonalArealViewModel();
            model.Prepod = prepodRepository.Prepods.Where(ob => ob.PrepodId == PrepodId).FirstOrDefault();
            if (model.Prepod == null)
            {
                throw new Exception("В личный кабинет не передан Id Препода");
            }
            foreach (var item in troopRepository.troops) // TODO немного не то, подумать как переделать, сейчас мы проходим по всем взводам и выбираем из них только нужные нам, создавая копию взвода и кладем теда только нужные темы
            {
                if (item.Disciplines.FindAll(ob => ob.PrepodId == model.Prepod.PrepodId).Count != 0)
                {
                    model.Troops.Add(item.CreateNewTroopOnliDisciplinesOnPrepod(model.Prepod.PrepodId));
                }
            }
            if (model.Troops.Find(ob => ob.TroopId == TroopId) != null)
            {
                return Json(model.Troops.Find(ob => ob.TroopId == TroopId).Disciplines.Select(ob => new
                {
                    Id = ob.DisciplineId,
                    Name = ob.Name
                }), JsonRequestBehavior.AllowGet);
            }else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult PersonalArea( int Id = 1)
        {
            PersonalArealViewModel model = new PersonalArealViewModel();
            model.Prepod = prepodRepository.Prepods.Where(ob => ob.PrepodId == Id).FirstOrDefault();
            if(model.Prepod == null)
            {
                throw new Exception("В личный кабинет не передан Id Препода");
            }
            foreach (var item in troopRepository.troops) // TODO немного не то, подумать как переделать, сейчас мы проходим по всем взводам и выбираем из них только нужные нам, создавая копию взвода и кладем теда только нужные темы
            {
                if(item.Disciplines.FindAll(ob=>ob.PrepodId == model.Prepod.PrepodId).Count != 0)
                {
                    model.Troops.Add(item.CreateNewTroopOnliDisciplinesOnPrepod(model.Prepod.PrepodId));
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult DisciplineAct(string action)
        {
            return RedirectToAction("PersonalArea");
        }
        [HttpPost]
        public void DeleteDiscipline(int? Id = null)
        {
            if(disciplineRepository.Disciplines.FirstOrDefault(ob=>ob.DisciplineId == Id) != null)
            {
                disciplineRepository.DeleteDiscipline(disciplineRepository.Disciplines.FirstOrDefault(ob => ob.DisciplineId == Id));
            }
        }
        [HttpPost]
        public void AddDiscipline(string Name, int? PrepodId, int? TroopId)
        {
            disciplineRepository.AddDiscipline(Name, PrepodId, TroopId);
        }
    }
}