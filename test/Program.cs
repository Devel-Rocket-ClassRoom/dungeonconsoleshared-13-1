using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

//DungeonGame 클래스디자인
//기존에 만든 텍스트 던전게임 코드를 DungeonGame 클래스로 이동
//기존 Main()에서 구현한 내용을 DungeonGame 클래스에
// 함수 PlayGame()를 만들어서 이동
//기존 모든 관련 함수를 DungeonGame 클래스 내부로 이동
//Main()에서 DungeonGame를 new로 만들고 PlayGame()호출
//기존 게임과 동일하게 작동할 것.   

//***던전게임 개선하기***1111
//1.부모 클래스 (플레이어, 몬스터 공통)
// - 공통 데이터, 메소드 선언
//2.플레이어 , 몬스터 클래스 정의
// = 각각 전용 데이터 선언
//3.플레이어 전용데이터, 메소드 (함수)
// - 예) 이동시 함수 사용
//4.몬스터 전용 데이터,메소드
//5.맵 클래스 만들고 코드정리
namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DungeonGame game = new DungeonGame("던전", 1);

            game.PlayGame(5);
        }
    }

    public struct GameData
    {
        public string stageName;
        public int dungeonCount;

        public GameData(string name, int count)
        {
            stageName = name;
            dungeonCount = count;
        }
    }
}
