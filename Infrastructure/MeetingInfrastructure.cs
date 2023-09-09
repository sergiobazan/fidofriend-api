using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class MeetingInfrastructure : IMeetingInfrastructure
    {
        private readonly AppDbContext _context;

        public MeetingInfrastructure(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateMeeting(Meeting meeting)
        {
            try
            {
                _context.Meetings.Add(meeting);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteMeeting(int id)
        {
            try
            {
                var result = await _context.Meetings.FindAsync(id);
                if (result == null) return false;
                _context.Meetings.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> FinishMeeting(int id, bool finish)
        {
            var findMeeting = await _context.Meetings.FindAsync(id);
            if (findMeeting == null) return false;
            findMeeting.Finish = finish;
            _context.Meetings.Update(findMeeting);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Meeting>> GetAllMeetingByClient(int id)
        {
            return await _context.Meetings.Where(e => e.ClientId == id).ToListAsync();
        }

        public async Task<IEnumerable<Meeting>> GetAllMeetingByVet(int id)
        {
            return await _context.Meetings.Where(e => e.VetId == id).ToListAsync();
        }

        public async Task<Meeting?> GetMeeting(int id)
        {
            return await _context.Meetings.FindAsync(id);
        }
    }
}
