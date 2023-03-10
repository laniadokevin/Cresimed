using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestYourself.Core.Entities.Database;
using TestYourself.Core.Interfaces;
using System.Security.Claims;
using TestYourself.Campus;
using Microsoft.AspNetCore.Authorization;
using TestYourself.Core.Entities.ViewModel.Campus;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TestYourself.Core.Entities.ViewModel.Admin.Grid;
using TestYourself.Data.Repositories;

namespace TestYourself.Campus.Controllers
{
    [Route("/Exam")]
    public class ExamController : Controller
    {
        private readonly IExamRepository _examRepository;
        private readonly ILogRepository _logRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPercentilRepository _percentilRepository;
        private readonly IQuestionStatRepository _questionStatRepository;

        public ExamController(
            IExamRepository examRepository,
            ILogRepository logRepository,
            IQuestionRepository questionRepository,
            ICategoryRepository categoryRepository,
            IReportRepository reportRepository,
            ISpecialtyRepository specialtyRepository,
            IUserRepository userRepository,
            IPercentilRepository percentilRepository,
            IQuestionStatRepository questionStatRepository
            )
        {
            _examRepository = examRepository ?? throw new ArgumentNullException(nameof(examRepository));
            _logRepository = logRepository ?? throw new ArgumentNullException(nameof(logRepository));
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _specialtyRepository = specialtyRepository?? throw new ArgumentNullException(nameof(specialtyRepository));
            _categoryRepository = categoryRepository?? throw new ArgumentNullException(nameof(categoryRepository));
            _reportRepository = reportRepository?? throw new ArgumentNullException(nameof(reportRepository));
            _percentilRepository = percentilRepository ?? throw new ArgumentNullException(nameof(percentilRepository));
            _questionStatRepository = questionStatRepository ?? throw new ArgumentNullException(nameof(questionStatRepository));
        }


        [Authorize(Roles = "SuperAdmin")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Customer")]
        [Route("~/Exam/CreateTest")]
        public IActionResult CreateTest()
        {
            var view = new CreateExamIndexViewModel();
            view.Categories = _categoryRepository.GetAll();
            view.Specialties = _specialtyRepository.GetAll();
            return View(view);
        }

        [HttpPost]
        [Route("~/Exam/CreateTest")]
        public IActionResult CreateTest(CreateExamIndexViewModel filters)
        {

            filters.Categories = _categoryRepository.GetAll();
            filters.Specialties = _specialtyRepository.GetAll();
            filters.UserID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var ex = _examRepository.GetNewExam(filters);

            ExamViewModel exam = new ExamViewModel();
            exam.Exam = (ex);
            exam.Questions = ex.ExamDetails.Select(x=>x.Question).ToList();

            return View("StartTest", exam);
        }

        [Authorize(Roles = "SuperAdmin")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Customer")]
        [Route("~/Exam/StartTest")]
        public IActionResult StartTest(ExamViewModel e)
        {
            return View(e);
        }

        [HttpPost]
        [Route("~/Exam/FinishTest")]
        public IActionResult FinishTest(List<ExamDetail> e)
        {
            _examRepository.AnswerExam(e);
            _percentilRepository.UpdatePercentil(e);
            _questionStatRepository.UpdateQuestionStat(e);



            return RedirectToAction("HistoryTest", new { examID = e.FirstOrDefault().ExamID });
        }

        [HttpPost]
        [Route("~/Exam/NewReport")]
        public string NewReport(Report report)
        {
            _reportRepository.InsertReport(report);
            return "Exito";
        }

        [HttpGet]
        [Route("~/Exam/HistoryTests")]
        public IActionResult HistoryTests(ExamHistoryGridViewModel view, int? pageNumber, string sortOrder, string currentFilter, string searchString)
        {

            var userId = int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault());



            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentSort"] = sortOrder;
            ViewData["IDSortParm"] = sortOrder == "ID" ? "ID_desc" : "ID";
            ViewData["ExamSortParm"] = sortOrder == "Exam" ? "Exam_desc" : "Exam";
            ViewData["CurrentFilter"] = searchString;


            view.Exams = _examRepository.GetAllFiltered(userId, sortOrder, currentFilter, searchString, pageNumber ?? 1);

            ViewData["TotalExams"] = _examRepository.TotalExamsCount(userId);
            //ViewData["FilteredExams"] = _examRepository.TotalFilteredCount(searchString);
            ViewData["ShowingExams"] = view.Exams.Count;


            return View(view);
        }

        [HttpGet]
        [Route("~/Exam/HistoryTest")]
        public IActionResult HistoryTest(int examID)
        {

            var e = _examRepository.GetById(examID);

            return View(e);
        }

        [HttpGet]
        [Route("~/Exam/TestStats")]
        public IActionResult TestStats()
        {
            var userId = int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault());

            var correctas = _examRepository.GetAllExams(userId);
            var view = _examRepository.GetAllBySpecialty(userId);

            return View(view);
        }


    }
}