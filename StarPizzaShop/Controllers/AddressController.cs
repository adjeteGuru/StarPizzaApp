﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarPizzaShop.DataAccess;
using StarPizzaShop.Database;
using StarPizzaShop.Models;

namespace StarPizzaShop.Controllers
{
    public class AddressController : Controller
    {
        
        private readonly IAddressRepo _repo;

        public AddressController(IAddressRepo repo)
        {
            _repo = repo;
        }

        // GET: Address
        public IActionResult GetAllAddresses()
        {
            var addressList =  _repo.GetAddresses();
            return View(addressList);
        }

        // GET: Address/Details/5
        public IActionResult GetById(int id)
        {
            var address = _repo.GetAddressById(id);            

            return View(address);
        }

        // GET: Address/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Address/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,BuildingDetails,HouseNo,Street,City,County,Postcode")] Address address)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(address);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(address);
        //}

        // GET: Address/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var address = await _context.Addresses.FindAsync(id);
        //    if (address == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(address);
        //}

        // POST: Address/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,BuildingDetails,HouseNo,Street,City,County,Postcode")] Address address)
        //{
        //    if (id != address.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(address);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AddressExists(address.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(address);
        //}

        // GET: Address/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var address = await _context.Addresses
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (address == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(address);
        //}

        // POST: Address/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var address = await _context.Addresses.FindAsync(id);
        //    _context.Addresses.Remove(address);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AddressExists(int id)
        //{
        //    return _context.Addresses.Any(e => e.Id == id);
        //}
    }
}
