using Models.Domain;

namespace DataAcess.Repos.IRepos
{
	public interface IChatRepository
	{
		Task<ChatMessage> SaveMessageAsync(string messageContent, string senderId, string receiverId, bool isDelivered);
		Task<List<ChatMessage>> GetMessagesAsync(string currentUserId, string otherUserId, int page, int pageSize);
		Task MarkMessagesAsDeliveredAsync(List<int> messageIds);
		Task<List<ChatContact>> GetChatContactsAsync(string currentUserId);

	}
}
