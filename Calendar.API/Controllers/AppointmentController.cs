using Calendar.Domain.Entities;
using Calendar.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Calendar.API.Controllers
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly ILogger<AppointmentController> _logger;
        private readonly IAppointmentDetailRepository _appointmentDetailRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        #region Ctor
        public AppointmentController(ILogger<AppointmentController> logger,
                                     IAppointmentDetailRepository appointmentDetailRepository,
                                     IAppointmentRepository appointmentRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _appointmentDetailRepository = appointmentDetailRepository ?? throw new ArgumentNullException(nameof(appointmentDetailRepository)); ;
            _appointmentRepository = appointmentRepository ?? throw new ArgumentNullException(nameof(appointmentRepository));

        }
        #endregion

        [HttpGet("{month}")]
        [ProducesResponseType(typeof(List<Appointment>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetAppointmentsByMonthAsync(int month)
        {
            var appointments = await _appointmentRepository.GetAllByMonthAsync(month);
            return Ok(appointments);
        }

        [HttpGet("{appointmentId}/appointment-detail")]
        [ProducesResponseType(typeof(AppointmentDetail), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetAppointmentDetailAsync(int appointmentId)
        {

            var appointmentDetail = await _appointmentDetailRepository.GetByAppointmentIdAsync(appointmentId);

            if (appointmentDetail is null)
            {
                return NotFound();
            }

            return Ok(appointmentDetail);
        }
    }
}
