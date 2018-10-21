// using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Csharp_Practice {
    public class LinqP {
        //初始化武林高手
        static List<MartialArtsMaster> master = new List<MartialArtsMaster>() {
            new MartialArtsMaster() { Id = 1, Name = "黄蓉", Age = 18, Menpai = "丐帮", Kongfu = "打狗棒法", Level = 9 },
            new MartialArtsMaster() { Id = 2, Name = "洪七公", Age = 70, Menpai = "丐帮", Kongfu = "打狗棒法", Level = 10 },
            new MartialArtsMaster() { Id = 3, Name = "郭靖", Age = 22, Menpai = "丐帮", Kongfu = "降龙十八掌", Level = 10 },
            new MartialArtsMaster() { Id = 4, Name = "任我行", Age = 50, Menpai = "明教", Kongfu = "葵花宝典", Level = 1 },
            new MartialArtsMaster() { Id = 5, Name = "东方不败", Age = 35, Menpai = "明教", Kongfu = "葵花宝典", Level = 10 },
            new MartialArtsMaster() { Id = 6, Name = "林平之", Age = 23, Menpai = "华山", Kongfu = "葵花宝典", Level = 7 },
            new MartialArtsMaster() { Id = 7, Name = "岳不群", Age = 50, Menpai = "华山", Kongfu = "葵花宝典", Level = 8 },
            new MartialArtsMaster() { Id = 8, Name = "令狐冲", Age = 23, Menpai = "华山", Kongfu = "独孤九剑", Level = 10 },
            new MartialArtsMaster() { Id = 9, Name = "梅超风", Age = 23, Menpai = "桃花岛", Kongfu = "九阴真经", Level = 8 },
            new MartialArtsMaster() { Id = 10, Name = "黄药师", Age = 23, Menpai = "梅花岛", Kongfu = "弹指神通", Level = 10 },
            new MartialArtsMaster() { Id = 11, Name = "风清扬", Age = 23, Menpai = "华山", Kongfu = "独孤九剑", Level = 10 }
        };
        //初始化武学
        static List<Kongfu> kongfu = new List<Kongfu>() {
            new Kongfu() { KongfuId = 1, KongfuName = "打狗棒法", Lethality = 90 },
            new Kongfu() { KongfuId = 2, KongfuName = "降龙十八掌", Lethality = 95 },
            new Kongfu() { KongfuId = 3, KongfuName = "葵花宝典", Lethality = 100 },
            new Kongfu() { KongfuId = 4, KongfuName = "独孤九剑", Lethality = 100 },
            new Kongfu() { KongfuId = 5, KongfuName = "九阴真经", Lethality = 100 },
            new Kongfu() { KongfuId = 6, KongfuName = "弹指神通", Lethality = 100 }

        };
        public static void Function() {
            var res = master?.Where(x => x.Level == 11).FirstOrDefault().Name;
            Console.WriteLine(res);
            int a = 1;
            string b = "asdf";
            string c = $"{a}+{b}";

            // var res = from k in kongfu
            // join m in master
            // on k.KongfuName equals m.Kongfu into mGroup
            // orderby mGroup.Count() descending
            // select new { kongfu = k.KongfuName, name = mGroup };
            // var res = from k in kongfu
            // from m in master
            // where k.KongfuName == m.Kongfu
            // select new { kongfu = k.KongfuName, name = m.Name };
            // var res = from m in master
            // group m by m.Menpai into g
            // select new { a = g.Key, b = g.Count() };
            // var res = kongfu.GroupJoin(
            //     master,
            //     k => k.KongfuName,
            //     m => m.Kongfu,
            //     (x, y) => new {
            //         a = x,
            //             b = y
            //     }
            // );

            // var res = kongfu.Join(
            //     master,
            //     k => k.KongfuName,
            //     m => m.Kongfu,
            //     (x, y) => new {
            //         a = x.KongfuName,
            //             b = y.Level
            //     }
            // ).OrderByDescending(x => x.b);
            // int[] arr = { 1, 23, 4, 5, 6, 78, 9, 89, 3, };
            // var res = arr.Where(x => x > 4).OrderBy(x => x).TakeWhile(x => x < 77).Select(x => x);
            // Console.WriteLine(res);
            // foreach (var temp in res) {
            //     Console.WriteLine(temp.kongfu);
            //     Console.WriteLine("------------------------------------------------------");
            //     foreach (var temp2 in temp.name) {
            //         Console.WriteLine("\t" + temp2.Name);
            //     }
            // }
            // Console.WriteLine(kongfu[1].ToString());
        }
        private struct Kongfu {
            public int KongfuId;
            public string KongfuName;
            public int Lethality;
            public override string ToString() {
                return KongfuName + "   " + Lethality;
            }

        }
        private struct MartialArtsMaster {
            public int Id;
            public string Name;
            public int Age;
            public string Menpai;
            public string Kongfu;
            public int Level;
            public override string ToString() {
                return Name + "   " + kongfu;
            }
        }
    }
}