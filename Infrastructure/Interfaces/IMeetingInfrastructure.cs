using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IMeetingInfrastructure
    {
        Task<bool> CreateMeeting(Meeting meeting);
        Task<bool> FinishMeeting(int id, bool finish);
        Task<bool> DeleteMeeting(int id);
        Task<Meeting?> GetMeeting(int id);
        Task<IEnumerable<Meeting>> GetAllMeetingByClient(int id);
        Task<IEnumerable<Meeting>> GetAllMeetingByVet(int id);
    }
}
