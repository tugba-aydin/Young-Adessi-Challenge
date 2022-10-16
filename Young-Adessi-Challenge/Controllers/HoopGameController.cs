using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Young_Adessi_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoopGameController : ControllerBase
    {
        [HttpGet("{gamerCount}")]
        public ActionResult<string> GetLastGamer(int gamerCount)
        {
            if (gamerCount > 0)
            {
                int[] gamerArray = new int[gamerCount]; // Tüm oyuncuları içeren liste
                int[] tempArray; // Oyuna devam eden oyuncuları içeren dizi
                int result = 0;
                if (gamerCount == 1) // 1 girilirse tek oyuncu var demektir
                {
                    result = gamerCount;
                    return Ok(result + " last gamer.");
                }
                else
                {
                    // Tüm oyuncular girilen oyuncu sayısı kadar sırayla oluşturulup diziye atanıyor
                    for (int k = 0; k < gamerCount; k++)
                    {
                        gamerArray[k] = k + 1;
                    }

                    while (result == 0)
                    {
                        // Devam edecek oyuncuların sayısını belirleme
                        if (gamerArray.Length % 2 == 1)
                        {
                            tempArray = new int[(gamerArray.Length / 2) + 1];
                        }
                        else
                        {
                            tempArray = new int[(gamerArray.Length / 2)];
                        }

                        int j = 0;
                        
                        // 1 eleman atlayıp, 1 elemana top atma oyunu oynanıyor 
                        for (int i = 0; i < gamerArray.Length; i += 2)
                        {
                            tempArray[j++] = gamerArray[i];
                        }
                        
                        // Son eleman  baştaki elemanı silecek mi bunun kontrolü yapılıyor
                        if (gamerArray.Length % 2 == 1)
                        {
                            var tempList = tempArray.ToList();
                            tempList.RemoveAt(0);
                            tempArray = tempList.ToArray();
                        }

                        // Her tur sonrası yeni oyuncular atanıyor
                        gamerArray = tempArray;

                        // 1 oyuncu kalınca kazananı belirleme 
                        if (gamerArray.Length == 1) result = gamerArray[0];
                    }

                    return Ok(result+ " last gamer.");
                }
            }
            else
            {
                return BadRequest("Please enter a value greater than 0.");
            }
        }
    }
}
