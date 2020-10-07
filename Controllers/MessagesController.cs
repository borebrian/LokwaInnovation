using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LokwaInnovation.DBContext;
using LokwaInnovation.Models;
using Telegram.Bot.Types;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;

namespace LokwaInnovation.Controllers
{
   
    public class MessagesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public MessagesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Messages

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user_id = User.Claims.FirstOrDefault(c => c.Type == "User_id").Value;
            //LETS GET CLIENTS NAME
            var contacts = await _context.Log_in
                .FirstOrDefaultAsync(m => m.User_ID.ToString() == user_id);


            var myConversation1 = _context.Messages.SingleOrDefault(x => x.Subject == contacts.Phone_number);
            if (myConversation1 == null)
            {
                return RedirectToAction(nameof(Create));

            }
            else
            {

                var chatID1 = myConversation1.chatID;
                var res1 = _context.Conversation.SingleOrDefault(x => x.chatID == chatID1.ToString());


                if (res1 == null)
                {
                    return RedirectToAction(nameof(Create));
                }
                else
                {
                    if (contacts.Roles == 1)
                    {
                        var subject = contacts.Phone_number;
                        var myConversation = _context.Messages.SingleOrDefault(x => x.Subject == contacts.Phone_number);
                        var chatID = myConversation.chatID;
                        var res = await _context.Conversation.ToListAsync();
                        ViewBag.Results = res;
                        return View(res);
                    }
                    else
                    {
                        var subject = contacts.Phone_number;
                        var myConversation = _context.Messages.SingleOrDefault(x => x.Subject == contacts.Phone_number);
                        var chatID = myConversation.chatID;
                        var res = await _context.Conversation.Where(x => x.chatID == chatID.ToString()).ToListAsync();
                        ViewBag.Results = res;
                        return View(res);
                    }
                }

            }

            //return Content(chatID1.ToString());

        }
        [Authorize]
        public async Task<IActionResult> chartBox([Optional] String id)
        {
            var rolse = User.Identity.Name;
            var user_id = User.Claims.FirstOrDefault(c => c.Type == "User_id").Value;
            //LETS GET CLIENTS NAME
            var contacts = await _context.Log_in
                .FirstOrDefaultAsync(m => m.User_ID.ToString() == user_id);
            ViewBag.name = contacts.Full_name;

            //LETS GET USER DETAILS
            HttpContext.Session.SetString("FullNames", contacts.Full_name);
            HttpContext.Session.SetString("PhoneNumber", contacts.Phone_number);
            HttpContext.Session.SetString("Roles", contacts.Roles.ToString());

            //LETS UPDATE MESSAGES ASSOCIATED TO THIS TO READ
            var friends = _context.Messages.Where(f => f.Subject == contacts.Phone_number).ToList();
            friends.ForEach(a => a.status = true);
            _context.SaveChanges();


            //LETS UPDATE THE CONVERSATION TO READ
            var conversation = _context.Conversation.Where(f => f.chatID == id).ToList();
            conversation.ForEach(a => a.status = true);
            _context.SaveChanges();

            // LETS GET ALL HIS/ HER MESSAGES

            var test = _context.Messages.Where(x => x.chatID.ToString() == id).ToList();
            ViewBag.ListOfMessages = test;

            return View();
            //}
        }

        // GET: Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messages = await _context.Messages
                .FirstOrDefaultAsync(m => m.ID == id);
            if (messages == null)
            {
                return NotFound();
            }

            return View(messages);
        }
        [Authorize]
        // GET: Messages/Create
        public IActionResult Create()
        {

            Random rnd = new Random();
            int month = rnd.Next(100000, 999999);
            ViewBag.randome = month;

            var user_id = User.Claims.FirstOrDefault(c => c.Type == "User_id").Value;
            //LETS GET CLIENTS NAME
            var contacts =  _context.Log_in
                .SingleOrDefault(m => m.User_ID.ToString() == user_id);
            ViewBag.subject = contacts.Phone_number;
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Subject,Date,Message,status,chatID,ID")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                var checkIfExists = await _context.Conversation
             .FirstOrDefaultAsync(m => m.ID == messages.chatID);

                //LETS CHECK IF THIS CONVERSATION ALREADY EXISTS
                if (checkIfExists == null)
                {
                    Conversation insertNewConversatio = new Conversation()
                    {
                        chatID = messages.chatID.ToString(),
                        status = false


                    };
                    _context.Add(insertNewConversatio);
                   
                    await _context.SaveChangesAsync();

                    _context.Add(messages);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                //IT DOES NOT EXISTS
                else
                {
                    var result = _context.Conversation.SingleOrDefault(b => b.chatID == checkIfExists.chatID);
                    result.status = true;
                    _context.Add(result);
                    _context.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();

                    _context.Add(messages);
                    await _context.SaveChangesAsync();



                    return RedirectToAction(nameof(Index));

                }

            }
            return View();
        }

        // GET: Messages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messages = await _context.Messages.FindAsync(id);
            if (messages == null)
            {
                return NotFound();
            }
            return View(messages);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Subject,Date,Message,status,chatID,ID")] Messages messages)
        {
            if (id != messages.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(messages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessagesExists(messages.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(messages);
        }

        // GET: Messages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messages = await _context.Messages
                .FirstOrDefaultAsync(m => m.ID == id);
            if (messages == null)
            {
                return NotFound();
            }

            return View(messages);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var messages = await _context.Messages.FindAsync(id);
            _context.Messages.Remove(messages);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MessagesExists(int id)
        {
            return _context.Messages.Any(e => e.ID == id);
        }
    }
}
