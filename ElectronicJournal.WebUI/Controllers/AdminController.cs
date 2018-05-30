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
        public JsonResult GetJsonMenu(int PrepodId, int? ParentId = null)
        {
            return Json(troopRepository.troops.Where(ob => ob.Disciplines.Where(dis => dis.PrepodId == PrepodId).Count() != 0).Select(p => new
            {
                id = p.TroopId.ToString(),
                parent = "#",
                text = p.Number,
                state = new
                {
                    disabled = false
                },
                children = false
            }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetJsonDiscipline(int TroopId, int PrepodId)
        {
            if (troopRepository.troops.FirstOrDefault(ob => ob.TroopId == TroopId) != null)
            {
                return Json(troopRepository.troops.FirstOrDefault(ob => ob.TroopId == TroopId).Disciplines.Where(ob => ob.PrepodId == PrepodId).Select(ob => new
                {
                    Id = ob.DisciplineId,
                    Name = ob.Name
                }), JsonRequestBehavior.AllowGet);
            }
            return null; // TODO Вызвать сдесь исключение и обработать его!
        }
        public JsonResult GetJsonTheme(int DisciplineId)
        {
            if (disciplineRepository.Disciplines.FirstOrDefault(ob => ob.DisciplineId == DisciplineId) != null)
            {
                return Json(disciplineRepository.Disciplines.FirstOrDefault(ob => ob.DisciplineId == DisciplineId).Theme.Select(ob => new
                {
                    Id = ob.ThemeId,
                    Title = ob.Title,
                    Count = ob.AmountHours,
                    Date = ob.Day.ToString("d")
                }), JsonRequestBehavior.AllowGet);
            }
            return null; // TODO Вызвать сдесь исключение и обработать его!
        }
        public ActionResult PersonalArea(int Id = 1)
        {
            PersonalArealViewModel model = new PersonalArealViewModel();
            model.Prepod = prepodRepository.Prepods.Where(ob => ob.PrepodId == Id).FirstOrDefault();
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
            return View(model);
        }
        //[HttpPost]
        //public ActionResult DisciplineAct(string action)
        //{
        //    return RedirectToAction("PersonalArea");
        //}
        [HttpPost]
        public void DeleteDiscipline(int? Id = null)
        {
            if (disciplineRepository.Disciplines.FirstOrDefault(ob => ob.DisciplineId == Id) != null)
            {
                disciplineRepository.DeleteDiscipline(disciplineRepository.Disciplines.FirstOrDefault(ob => ob.DisciplineId == Id));
            }
        }
        [HttpPost]
        public void AddDiscipline(string Name, int? PrepodId, int? TroopId)
        {
            disciplineRepository.AddDiscipline(Name, PrepodId, TroopId);
        }
        [HttpPost]
        public void DeleteTheme(int? Id = null)
        {
            if (disciplineRepository.Disciplines.FirstOrDefault(ob => ob.Theme.FirstOrDefault(tm => tm.ThemeId == Id) != null) != null)
            {
                disciplineRepository.DeleteTheme(disciplineRepository.Disciplines.FirstOrDefault(ob => ob.Theme.FirstOrDefault(tm => tm.ThemeId == Id) != null).Theme.FirstOrDefault(tm => tm.ThemeId == Id));
            }
        }
        [HttpPost]
        public void AddTheme(int DisciplineId, string Title, int Count, DateTime Date)
        {
            disciplineRepository.AddTheme(DisciplineId, Title, Count, Date);
        }
    }
}