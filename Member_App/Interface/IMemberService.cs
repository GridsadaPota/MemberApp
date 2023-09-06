using Member_App.Models;

namespace Member_App.Interface
{
    public interface IMemberService
    {
        IEnumerable<MemberModel> GetAll();
        bool AddMember(MemberModel memberModel);
        MemberModel GetMemberByid (int id);
    }
}
