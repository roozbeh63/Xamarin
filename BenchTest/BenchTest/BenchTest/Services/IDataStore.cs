using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchTest.Services
{
	public interface IDataStore<T>
	{
		bool AddItemAsync(T item);
		bool UpdateItemAsync(T item);
		bool DeleteItemAsync(T item);
		List<T>  GetItems(int id, int cat);
		void InitializeAsync();
	}
}
