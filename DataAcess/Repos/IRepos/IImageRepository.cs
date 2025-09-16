using Models.Domain;

namespace DataAcess.Repos.IRepos
{
	public interface IImageRepository
	{
		Task<Image> Upload(Image image);
		public string GetImageUrl(int imageId);
	}
}
