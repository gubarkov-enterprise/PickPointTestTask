using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PickPointTestTask.Models;
using PickPointTestTask.Models.ViewModels;
using PickPointTestTask.Services;

namespace PickPointTestTask.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }


        [HttpPost]
        public Task<int> Create(OrderCreatingModel model) => _service.CreateOrder(model);

        [HttpGet]
        public Task<List<OrderViewModel>> Get() => _service.GetAllOrders();

        [HttpPatch]
        public Task Update(OrderEditingModel model) => _service.EditOrder(model);

        [HttpPatch("cancel")]
        public Task CancelOrder([FromQuery] int orderId) => _service.CancelOrder(orderId);
    }
}