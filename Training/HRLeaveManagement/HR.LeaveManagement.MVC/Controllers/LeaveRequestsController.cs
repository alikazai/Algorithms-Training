using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR.LeaveManagement.MVC.Controllers;

[Authorize]
public class LeaveRequestsController : Controller
{
    private readonly ILeaveTypeService _leaveTypeService;
    private readonly ILeaveRequestService _leaveRequestService;
    private readonly IMapper _mapper;
    // GET
    public LeaveRequestsController(ILeaveTypeService leaveTypeService, ILeaveRequestService leaveRequestService, IMapper mapper)
    {
        _leaveTypeService = leaveTypeService;
        _leaveRequestService = leaveRequestService;
        _mapper = mapper;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        var model = await _leaveRequestService.GetAdminLeaveRequestList();
        return View(model);
    }

    // GET: LeaveRequest/Details/Id
    public async Task<IActionResult> Details(int id)
    {
        var model = await _leaveRequestService.GetLeaveRequest(id);
        return View(model);
    }

    // GET: LeaveRequest/Create
    public async Task<IActionResult> Create()
    {
        var leaveTypes = await _leaveTypeService.GetLeaveTypes();
        var leaveTypeItems = new SelectList(leaveTypes, "Id", "Name");
        var model = new CreateLeaveRequestVM()
        {
            LeaveTypes = leaveTypeItems
        };

        return View(model);
    }

    // POST: LeaveRequest/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateLeaveRequestVM leaveRequest)
    {
        if (ModelState.IsValid)
        {
            var response = await _leaveRequestService.CreateLeaveRequest((leaveRequest));
            if (response.Success)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", response.ValidationErrors);
        }

        var leaveTypes = await _leaveTypeService.GetLeaveTypes();
        var leaveTypeItems = new SelectList(leaveTypes, "Id", "Name");
        leaveRequest.LeaveTypes = leaveTypeItems;

        return View(leaveRequest);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> ApproveRequest(int id, bool approved)
    {
        try
        {
            await _leaveRequestService.ApproveLeaveRequest(id, approved);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return RedirectToAction(nameof(Index)); 
        }
    }
}