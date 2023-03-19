using prolab21.Entity;
using prolab21.Entity.Enums;
using prolab21.Helpers;

namespace prolab21 {
    public static class Maze {
        public static async Task<Response<List<List<Block>>>> CreateMap(string url) {
            Response<List<List<Block>>> map = new Response<List<List<Block>>>();
            Http client = new Http(url);
            Response<string> mapDataResponse = await client.Get(url);
            if(!mapDataResponse.IsSuccess){
                map.IsSuccess = false;
                map.ErrorMessage = mapDataResponse.ErrorMessage;
                return map;
            }
            map.Result = MazeHelper.SetMap(mapDataResponse.Result);
            map.IsSuccess = map.Result.Count > 0;
            map.ErrorMessage = !map.IsSuccess ? "Bilinmeyen hata oluştu!" : string.Empty;
            return map;
        }

        public static Response<List<List<Block>>> CreateMap(int width, int height) {
            Response<List<List<Block>>> map = new Response<List<List<Block>>>();
            if((width < 20 && width > 100) || (height < 20 && height > 100) ) {
                map.IsSuccess = false;
                map.ErrorMessage = string.Format("Haritanın Genişliği veya Yüksekliği 20-100 arasında olmadılıdır! Verilen Genişlik: {0}, Verilen Yükseklik {1}", width, height);
                return map;
            }
            return map;
        }
    }
}