using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MeetingDomain : IMeetingDomain
    {
        private readonly IMeetingInfrastructure _infrastructure;

        public MeetingDomain(IMeetingInfrastructure infrastructure)
        {
            _infrastructure = infrastructure;
        }

        public async Task<bool> CreateMeeting(Meeting meeting)
        {
            return await _infrastructure.CreateMeeting(meeting);
        }

        public async Task<bool> DeleteMeeting(int id)
        {
            return await _infrastructure.DeleteMeeting(id);
        }

        public async Task<bool> FinishMeeting(int id, bool finish)
        {
            return await _infrastructure.FinishMeeting(id, finish);
        }

        public async Task<IEnumerable<Meeting>> GetAllMeetingByClient(int id)
        {
            return await _infrastructure.GetAllMeetingByClient(id);
        }

        public async Task<IEnumerable<Meeting>> GetAllMeetingByVet(int id)
        {
            return await _infrastructure.GetAllMeetingByVet(id);
        }

        public async Task<Meeting?> GetMeeting(int id)
        {
            return await _infrastructure.GetMeeting(id);
        }
    }
}
