﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Sparta2ndWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartScene startScene1 = new StartScene();
            InfortantInformation information1 = new InfortantInformation();
            startScene1.Intro();
            int chosen = int.Parse(Console.ReadLine());
            while (true)
            {
                if (chosen == 1 || chosen == 2 || chosen == 3)
                {
                    switch (chosen)
                    {
                        case 1: //상태보기
                            information1.Stats();
                            chosen = int.Parse(Console.ReadLine());
                            while (true)
                            {
                                if (chosen == 0) //나가기
                                {
                                    startScene1.Intro();
                                    break;
                                }
                                else
                                    Console.WriteLine(" 잘못된 입력입니다.");
                                    chosen = int.Parse(Console.ReadLine());
                            }
                            break;
                        case 2: //인벤토리
                            information1.Inventory();
                            chosen = int.Parse(Console.ReadLine());
                            while (true)
                            {
                                if (chosen == 0) //나가기
                                {
                                    startScene1.Intro();
                                    break;
                                }
                                else if (chosen == 1) //장착 관리
                                {
                                    information1.ItemOnOff();
                                    chosen = int.Parse(Console.ReadLine());
                                    while (true)
                                    {
                                        if (chosen == 0) //나가기
                                        {
                                            startScene1.Intro();
                                            break;
                                        }
                                        else if (!information1.ListEmpty()) //구매목록에 아이템이 있으면,
                                        {
                                            while (true)
                                            {
                                                information1.DoOnOff(chosen);
                                                information1.ItemOnOff();
                                                chosen = int.Parse(Console.ReadLine());
                                                if (chosen == 0)
                                                {
                                                    startScene1.Intro();
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine(" 잘못된 입력입니다.");
                                            chosen = int.Parse(Console.ReadLine());
                                        }
                                    }
                                    break;
                                }
                                else
                                    Console.WriteLine(" 잘못된 입력입니다.");
                                    chosen = int.Parse(Console.ReadLine());
                            }
                            break;
                        case 3: //상점
                            information1.Store();
                            chosen = int.Parse(Console.ReadLine());
                            while (true)
                            {
                                if (chosen == 0) //나가기
                                {
                                    startScene1.Intro();
                                    break;
                                }
                                else if (chosen == 1) //아이템 구매화면
                                {
                                    information1.Buy();
                                    chosen = int.Parse(Console.ReadLine()); //0을 선택하면 메인화면으로// 1구매를 선택하면
                                    while (true)
                                    {
                                        if (chosen == 0)
                                        {
                                            startScene1.Intro();
                                            break;
                                        }
                                        else if (chosen == 1 || chosen == 2 || chosen == 3 || chosen == 4 || chosen == 5 || chosen == 6)
                                        {
                                            while (true)
                                            {
                                                information1.BoughtList(chosen);
                                                chosen = int.Parse(Console.ReadLine());
                                                if (chosen == 0)
                                                {
                                                    startScene1.Intro();
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine(" 잘못된 입력입니다.");
                                            chosen = int.Parse(Console.ReadLine());
                                        }
                                    }
                                    break;
                                }
                                else
                                    Console.WriteLine(" 잘못된 입력입니다.");
                                    chosen = int.Parse(Console.ReadLine());
                            }
                            break;
                    }
                }
                else
                    Console.WriteLine(" 잘못된 입력입니다.");
                    chosen = int.Parse(Console.ReadLine());
            }
        }

        //게임 시작 화면
        class StartScene
        {
            public void Intro()
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(" 스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine(" 이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine("");
                Console.WriteLine(" 1. 상태 보기");
                Console.WriteLine(" 2. 인벤토리");
                Console.WriteLine(" 3. 상점");
                Console.WriteLine("");
                Console.Write(" 원하시는 행동을 입력해주세요. \n >> ");
            }
        }

        //아이템정보 클래스
        class InfortantInformation
        {
            //현재 재화상태
            int gold = 1500;
            
            public void GoldCaculation(int a)
            {
                switch (a)
                {
                    case 1:
                        if (gold >= 1000)
                        {
                            gold -= 1000;
                            items.Add(a, "수련자 갑옷     | 방어력 +5  | 수련에 도움을 주는 갑옷입니다.                   ");
                            Console.WriteLine(" 구매를 완료했습니다.");
                        }
                        else
                            Console.WriteLine(" Gold 가 부족합니다.");
                        break;
                    case 2:
                        if (gold >= 1800)
                        {
                            gold -= 1800;
                            items.Add(a, "무쇠갑옷        | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다.               ");
                            Console.WriteLine(" 구매를 완료했습니다.");
                        }
                        else
                            Console.WriteLine(" Gold 가 부족합니다.");
                        break;
                    case 3:
                        if (gold >= 3500)
                        {
                            gold -= 3500;
                            items.Add(a, "스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.");
                            Console.WriteLine(" 구매를 완료했습니다.");
                        }
                        else
                            Console.WriteLine(" Gold 가 부족합니다.");
                        break;
                    case 4:
                        if (gold >= 600)
                        {
                            gold -= 600;
                            items.Add(a, "낡은 검         | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다.                  ");
                            Console.WriteLine(" 구매를 완료했습니다.");
                        }
                        else
                            Console.WriteLine(" Gold 가 부족합니다.");
                        break;
                    case 5:
                        if (gold >= 1500)
                        {
                            gold -= 1500;
                            items.Add(a, "청동 도끼       | 공격력 +5  |  어디선가 사용됐던거 같은 도끼입니다.            ");
                            Console.WriteLine(" 구매를 완료했습니다.");
                        }
                        else
                            Console.WriteLine(" Gold 가 부족합니다.");
                        break;
                    case 6:
                        if (gold >= 2700)
                        {
                            gold -= 2700;
                            items.Add(a, "스파르타의 창   | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다.  ");
                            Console.WriteLine(" 구매를 완료했습니다.");
                        }
                        else
                            Console.WriteLine(" Gold 가 부족합니다.");
                        break;
                }
            }

            //구매 목록
            Dictionary<int, string> items = new Dictionary<int, string>();

            //구매에 따른 소지 아이템 목록 작성
            public void BoughtList(int a)
            {
                int count = items.Count;
                if (count == 0) 
                {
                    if (a < 1 && a > 6)
                        Console.WriteLine(" 잘못된 입력입니다.");
                    else 
                    {
                        GoldCaculation(a);
                    }
                }
                else //데이터 존재
                {
                    if (a < 1 && a > 6)
                        Console.WriteLine(" 잘못된 입력입니다.");
                    else
                    {
                        if (!items.ContainsKey(a))
                        {
                            GoldCaculation(a);
                        }
                        else
                        {
                            Console.WriteLine(" 이미 구매한 아이템입니다.");
                        }
                    }
                }
            }

            //아이템 정보
            public void ItemList(int x) //x=0: 상점 //x=-1: 아이템구매
            {
                int[,] itemStats = new int[6, 2]
                {
                    {0, 1},
                    {0, 1},
                    {0, 1},
                    {0, 1},
                    {0, 1},
                    {0, 1}
                };
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (itemStats[i, j] == 0 && x == 0)
                        {
                            Console.Write(" - ");
                        }
                        else if (itemStats[i, j] == 0 && x == 1)
                        {
                            int k = i + 1;
                            Console.Write(" - {0} ", k);
                        }
                        else if (itemStats[i, j] == 1)
                        {
                            switch (i)
                            {
                                case 0:
                                    if (x==0 && items.ContainsKey(1)) //상점창에서 1번이 존재하면, 구매완료 표시
                                        Console.Write("수련자 갑옷     | 방어력 +5  | 수련에 도움을 주는 갑옷입니다.                   |  구매완료");
                                    else
                                        Console.Write("수련자 갑옷     | 방어력 +5  | 수련에 도움을 주는 갑옷입니다.                   |  1000 G");
                                    break;
                                case 1:
                                    if (x == 0 && items.ContainsKey(2))
                                        Console.Write("무쇠갑옷        | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다.               |  구매완료");
                                    else
                                        Console.Write("무쇠갑옷        | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다.               |  1800 G");
                                    break;
                                case 2:
                                    if (x == 0 && items.ContainsKey(3))
                                        Console.Write("스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.|  구매완료");
                                    else
                                        Console.Write("스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.|  3500 G");
                                    break;
                                case 3:
                                    if (x == 0 && items.ContainsKey(4))
                                        Console.Write("낡은 검         | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다.                  |   구매완료");
                                    else
                                        Console.Write("낡은 검         | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다.                  |   600 G");
                                    break;
                                case 4:
                                    if (x == 0 && items.ContainsKey(5))
                                        Console.Write("청동 도끼       | 공격력 +5  |  어디선가 사용됐던거 같은 도끼입니다.            |  구매완료");
                                    else
                                        Console.Write("청동 도끼       | 공격력 +5  |  어디선가 사용됐던거 같은 도끼입니다.            |  1500 G");
                                    break;
                                case 5:
                                    if (x == 0 && items.ContainsKey(6))
                                        Console.Write("스파르타의 창   | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다.  |  구매완료");
                                    else
                                        Console.Write("스파르타의 창   | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다.  |  2700 G");
                                    break;
                            }
                        }
                    }
                    Console.WriteLine();
                }
            }

            //아이템구매창
            public void Buy()
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(" 상점 - 아이템 구매");
                Console.WriteLine(" 필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine("");
                Console.WriteLine(" [보유 골드]");
                Console.WriteLine(" {0} G", gold);
                Console.WriteLine("");
                Console.WriteLine(" [아이템 목록]");
                ItemList(1); 
                Console.WriteLine("");
                Console.WriteLine(" 0. 나가기");
                Console.WriteLine("");
                Console.Write(" 원하시는 행동을 입력해주세요. \n >> ");
            }

            //상점
            public void Store()
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(" 상점");
                Console.WriteLine(" 필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine("");
                Console.WriteLine(" [보유 골드]");
                Console.WriteLine(" {0} G", gold);
                Console.WriteLine("");
                Console.WriteLine(" [아이템 목록]");
                ItemList(0); 
                Console.WriteLine("");
                Console.WriteLine(" 1. 아이템 구매");
                Console.WriteLine(" 0. 나가기");
                Console.WriteLine("");
                Console.Write(" 원하시는 행동을 입력해주세요. \n >> ");
            }

            //아이템 목록이 비어있는지 확인
            public bool ListEmpty()
            {
                if (items.Count == 0)
                {
                    return true;
                }
                return false;

            }
            //아이템 목록에 해당 숫자의 아이템이 있는지 확인
            //public bool CheckItemNumber(int a)
            //{
            //    if (items.ContainsValue[a]) //값 확인
            //    {
            //        return true;
            //    }
            //    return false;
            //}

            //장착 중인 아이템 리스트
            Dictionary<int, string> onList = new Dictionary<int, string>();

            //아이템 장착 및 해제
            public void DoOnOff(int a)
            {
                if (items.TryGetValue(a, out string one))
                {
                    if (!onList.ContainsKey(a))
                    {
                        onList.Add(a, one); //장착(onList에 추가)
                    }
                    else
                    {
                        onList.Remove(a); //미장착(onList에서 제거)
                    }
                }
            }

            //장착 표시된 아이템 리스트
            public void OnOffMarkList(int x) //x=0:인벤토리 x=1:장착관리
            {
                if (items.Count > 0)
                {
                    List<string> valueList = new List<string>();
                    foreach (KeyValuePair<int, string> item in items)
                    {
                        if (item.Key != null)
                        {
                            valueList.Add(item.Value);
                        }
                    }
                    foreach (string value in valueList)
                    {
                        for (int i = 1; i < valueList.Count + 1; i++)
                        {
                            if (onList.ContainsKey(i) && x == 1) //장착관리 목록리스트
                            {
                                Console.WriteLine(" - {0} [E]{1}", i, value);
                            }
                            else if (!onList.ContainsKey(i) && x == 1)
                            {
                                Console.WriteLine(" - {0} {1}", i, value);
                            }
                            else if (onList.ContainsKey(i) && x == 0) //인벤토리 리스트
                            {
                                Console.WriteLine(" - [E]{0}", value);
                            }
                            else if (!onList.ContainsKey(i) && x == 0)
                            {
                                Console.WriteLine(" - {0}", value);
                            }
                                
                        }
                    }
                }
            }

            //장착 관리
            public void ItemOnOff()
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(" 인벤토리 - 장착 관리");
                Console.WriteLine(" 보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine("");
                Console.WriteLine(" [아이템 목록]");
                OnOffMarkList(1); //x=0:인벤토리 x=1:장착관리
                Console.WriteLine("");
                Console.WriteLine(" 0. 나가기");
                Console.WriteLine("");
                Console.Write(" 원하시는 행동을 입력해주세요. \n >> ");
            }

            //인벤토리
            public void Inventory()
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(" 인벤토리");
                Console.WriteLine(" 보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine("");
                Console.WriteLine(" [아이템 목록]");
                OnOffMarkList(0); //x=0:인벤토리 x=1:장착관리
                Console.WriteLine("");
                Console.WriteLine(" 1. 장착 관리");
                Console.WriteLine(" 0. 나가기");
                Console.WriteLine("");
                Console.Write(" 원하시는 행동을 입력해주세요. \n >> ");
            }

            //캐릭터 상태 반영
            public void ChangedStats()
            {
                int[] playerStats = { 1, 10, 5, 100 };
                int level = playerStats[0];
                int atk = playerStats[1];
                int def = playerStats[2];
                int hp = playerStats[3];
                for(int i = 1; i < onList.Count+1; i++)
                {
                    if (i == 1)
                    {
                        def += 5;
                    }
                    else if(i == 2)
                    {
                        def += 9;
                    }
                    else if(i == 3)
                    {
                        def += 15;
                    }
                    else if (i == 4)
                    {
                        atk += 2;
                    }
                    else if (i == 5)
                    {
                        atk += 5;
                    }
                    else if (i == 6)
                    {
                        atk += 7;
                    }
                }
                string sLevel = level.ToString("D2");
                Console.WriteLine(" Lv. {0}", sLevel);
                Console.WriteLine(" Shin ( 전사 )");
                Console.WriteLine(" 공격력 : {0}", atk);
                Console.WriteLine(" 방어력 : {0}", def);
                Console.WriteLine(" 체 력 : {0}", hp);
            }

            //캐릭터 정보(상태보기)
            public void Stats()
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(" 상태 보기");
                Console.WriteLine(" 캐릭터의 정보가 표시됩니다.");
                Console.WriteLine("");
                ///////////////////////////////////////
                int[] playerStats = { 1, 10, 5, 100 };
                int level = playerStats[0];
                int atk = playerStats[1];
                int def = playerStats[2];
                int hp = playerStats[3];
                string sLevel = level.ToString("D2");
                Console.WriteLine(" Lv. {0}", sLevel);
                Console.WriteLine(" Shin ( 전사 )");
                Console.WriteLine(" 공격력 : {0}", atk);
                Console.WriteLine(" 방어력 : {0}", def);
                Console.WriteLine(" 체 력 : {0}", hp);
                //////////////////////////////////////////
                Console.WriteLine(" Gold : {0} G", gold);
                //장비 착용 여부에 따라서 if절을 이용하여 stat 올리기
                Console.WriteLine("");
                Console.WriteLine(" 0. 나가기");
                Console.WriteLine("");
                Console.Write(" 원하시는 행동을 입력해주세요. \n >> ");
            }
        }
    }
}
