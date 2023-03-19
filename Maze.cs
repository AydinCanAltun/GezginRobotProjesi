using GezginRobotProjesi.Entity;
using GezginRobotProjesi.Entity.Enums;
using GezginRobotProjesi.Helpers;

namespace GezginRobotProjesi {
    public static class Maze {
        /// <summary>
        /// Verilen URL'deki metni okur ve 2d blok array'ine çevirir.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Genişlik ve Uzunluk parametrelerini alarak rastgele labirent oluşturur.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Response<List<List<Block>>> CreateMap(Labyrinth entity) {
            Response<List<List<Block>>> map = new Response<List<List<Block>>>();
            if((entity.Width < 20 && entity.Width > 100) || (entity.Heigth < 20 && entity.Heigth > 100) ) {
                map.IsSuccess = false;
                map.ErrorMessage = string.Format("Haritanın Genişliği veya Yüksekliği 20-100 arasında olmadılıdır! Verilen Genişlik: {0}, Verilen Yükseklik {1}", entity.Width, entity.Heigth);
                return map;
            }
            map.IsSuccess = true;
            map.Result = LabyrinthHelper.SetMap(entity);
            return map;
        }
    }
}