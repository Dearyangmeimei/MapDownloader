﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET;
using GMap.NET.MapProviders;

namespace GMapProvidersExt.Tencent
{
    public class SoSoTerrainMapProvider : SoSoMapProviderBase
    {
        // Fields
        private readonly string cnName;
        private readonly Guid id = new Guid("c14499fa-ae42-4317-a0aa-8d46b204662f");
        public static readonly SoSoTerrainMapProvider Instance;
        private readonly string name;
        public static string UrlFormat;

        // Methods
        static SoSoTerrainMapProvider()
        {
            UrlFormat = "http://p{0}.map.gtimg.com/{1}/{2}.{3}";
            Instance = new SoSoTerrainMapProvider();
        }

        private SoSoTerrainMapProvider()
        {
            this.name = "SoSoTerrainMap";
            this.cnName = "腾讯地形地图（无注记）";
        }

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            string url = string.Format(UrlFormat, new object[] { GMapProvider.GetServerNum(pos, SoSoMapProviderBase.maxServer), "demTiles", base.GetSosoMapTileNo(pos, zoom), "jpg" });
            return base.GetTileImageUsingHttp(url);
        }

        // Properties
        public string CnName
        {
            get
            {
                return this.cnName;
            }
        }

        public override Guid Id
        {
            get
            {
                return this.id;
            }
        }

        public override string Name
        {
            get
            {
                return this.name;
            }
        }
    }


}
