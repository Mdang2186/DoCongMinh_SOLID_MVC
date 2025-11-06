using Microsoft.AspNetCore.Mvc;
using DoCongMinh.Models;
using DoCongMinh.Services.Interfaces;
using Microsoft.EntityFrameworkCore; // Cần cho lỗi Concurrency

namespace DoCongMinh.Controllers
{
    public class ProductsController : Controller
    {
        // Controller CHỈ nói chuyện với Service
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GET: /Products
        public async Task<IActionResult> Index()
        {
            var products = await _service.GetAllProductsAsync();
            return View(products); // Trả về View/Products/Index.cshtml
        }

        // GET: /Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product); // Trả về View/Products/Details.cshtml
        }

        // GET: /Products/Create
        public IActionResult Create()
        {
            return View(); // Trả về View/Products/Create.cshtml
        }

        // POST: /Products/Create (An toàn)
        [HttpPost]
        [ValidateAntiForgeryToken] // An toàn: Chống tấn công CSRF
        public async Task<IActionResult> Create(
            // An toàn: Chống Over-posting, chỉ nhận các trường này
            [Bind("Name,Description,Price,Stock")] Product product)
        {
            // Kiểm tra Validation (từ Model)
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.CreateProductAsync(product);
                    return RedirectToAction(nameof(Index)); // Thành công -> Về trang chủ
                }
                catch (ArgumentException ex) // Bắt lỗi nghiệp vụ từ Service
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            // Nếu lỗi: Trả về form với dữ liệu đã nhập
            return View(product);
        }

        // GET: /Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product); // Trả về View/Products/Edit.cshtml
        }

        // POST: /Products/Edit/5 (An toàn)
        [HttpPost]
        [ValidateAntiForgeryToken] // An toàn: Chống CSRF
        public async Task<IActionResult> Edit(int id,
            // An toàn: Chống Over-posting (bao gồm cả Id)
            [Bind("Id,Name,Description,Price,Stock")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateProductAsync(product);
                }
                // An toàn: Xử lý lỗi nếu 2 người cùng sửa 1 lúc
                catch (DbUpdateConcurrencyException)
                {
                    if (await _service.GetProductByIdAsync(id) == null)
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: /Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product); // Trả về View/Products/Delete.cshtml
        }

        // POST: /Products/Delete/5 (An toàn)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] // An toàn: Chống CSRF
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}