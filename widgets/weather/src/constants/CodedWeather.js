var CodedWeather = {
    CloudCodes: {
        'CL': {
            EN: "Clear",
            KR: "맑음"
        },
        'FW': {
            EN: "Fair/Mostly sunny",
            KR: "대체로 맑음"
        },
        'SC': {
            EN: "Partly cloudy",
            KR: "구름 조금"
        },
        'BK': {
            EN: "Mostly Cloudy",
            KR: "구름 많음"
        },
        'OV': {
            EN: "Cloudy/Overcast",
            KR: "흐림"
        },
        'R': {
            EN: "Rain",
            KR: "비"
        }
    },

    CoverageCodes: {
        'AR': {
            EN: "Areas of",
            KR: "좁은 영역의"
        },
        'BR': {
            EN: "Brief",
            KR: "잠시 동안의"
        },
        'C':{
            EN: "Chance of",
            KR: "확실하지 않은"
        },
        'D': {
            EN: "Definite",
            KR: "확실한"
        },
        'FQ': {
            EN: "Frequent",
            KR: "빈번한"
        },
        'IN': {
            EN: "Intermittent",
            KR: "간헐적인"
        },
        'IS': {
            EN: "Isolated",
            KR: "국지적인"
        },
        'L': {
            EN: "Likely",
            KR: "같은"
        },
        'NM': {
            KR: "Numerous",
            EN: "많은"
        },
        'O': {
            EN: "Occasional",
            KR: "가끔"
        },
        'PA': {
            EN: "Patchy",
            KR: "고르지 못한"
        },
        'PD': {
            EN: "Periods of",
            KR: "장기간의"
        },
        'S': {
            EN: "Slight chance",
            KR: "희박한"
        },
        'SC': {
            EN: "Scattered",
            KR: "드물게"
        },
        'VC': {
            EN: "In the vicinity/Nearby",
            KR: "근처에서"
        },
        'WD': {
            EN: "Widespread",
            KR: "광범위한"
        }
    },

    IntensityCodes: {
        'VL': {
            EN: "Very light",
            KR: "매우 약한"
        },
        'L': {
            EN: "Light",
            KR: "약한"
        },
        'H': {
            EN: "Heavy",
            KR: "강한"
        },
        'VH': {
            EN: "Very heavy",
            KR: "매우 강한"
        }
    },

    WeatherCodes: {
        'A': {
            EN: "Hail",
            KR: "우박"
        },
        'BD': {
            EN: "Blowing dust",
            KR: "풍진"
        },
        'BN': {
            EN: "Blowing sand",
            KR: "황사"
        },
        'BR': {
            EN: "Mist",
            KR: "안개"
        },
        'BS': {
            EN: "Blowing snow",
            KR: "날린 눈"
        },
        'BY': {
            EN: "Blowing spray",
            KR: "날린 물보라"
        },
        'F': {
            EN: "Fog",
            KR: "안개"
        },
        'FR': {
            EN: "Frost",
            KR: "혹한"
        },
        'H': {
            EN: "Haze",
            KR: "실안개"
        },
        'IC': {
            EN: "Ice crystals",
            KR: "세빙"
        },
        'IF': {
            EN: "Ice fog",
            KR: "빙무"
        },
        'IP': {
            EN: "Ice pellets / Sleet",
            KR: "우박"
        },
        'K': {
            EN: "Smoke",
            KR: "스모크"
        },
        'L': {
            EN: "Drizzle",
            KR: "이슬비"
        },
        'R': {
            EN: "Rain",
            KR: "비"
        },
        'RW': {
            EN: "Rain showers",
            KR: "소나기"
        },
        'RS': {
            EN: "Rain/snow mix",
            KR: "비와 눈"
        },
        'SI': {
            EN: "Snow/sleet mix",
            KR: "눈과 진눈깨비"
        },
        'WM': {
            EN: "Wintry mix (snow, sleet, rain)",
            KR: "눈/진눈깨비/비"
        },
        'S': {
            EN: "Snow",
            KR: "눈"
        },
        'SW': {
            EN: "Snow showers",
            KR: "소낙눈"
        },
        'T': {
            EN: "Thunderstorms",
            KR: "천둥번개"
        },
        'UP': {
            EN: "Unknown precipitation",
            KR: "알 수 없음"
        },
        'VA': {
            EN: "Volcanic ash",
            KR: "화산재"
        },
        'WP': {
            EN: "Waterspouts",
            KR: "용오름/물기둥"
        },
        'ZF': {
            EN: "Freezing fog",
            KR: "언 안개"
        },
        'ZL': {
            EN: "Freezing drizzle",
            KR: "언 이슬비"
        },
        'ZR': {
            EN: "Freezing rain",
            KR: "언 비"
        },
        'ZY': {
            EN: "Freezing spray",
            KR: "언 물보라"
        }
    },

    Icons: {
        'am_pcloudy.png': 'cloudSun',
        'am_pcloudyr.png': 'cloudDrizzleSunAlt',
        'am_showers.png': 'cloudDrizzleAlt',
        'am_snowshowers.png': 'cloudSnowSun',
        'am_tstorm.png': 'cloudLightningSun', //TODO: cloudLightning -> cloudLightningSun 태양/번개 아이디 변경하기
        'blizzard.png': 'cloudSnowAlt',
        'blizzardn.png': 'cloudSnowAlt',
        'blowingsnow.png': 'cloudSnowAlt',
        'blowingsnown.png': 'cloudSnowAlt',
        'chancetstorm.png': 'cloudLightningSun',
        'chancetstormn.png': 'cloudLightningMoon',
        'clear.png': 'sun',
        'clearn.png': 'moon',
        'clearw.png': 'sun',
        'clearwn.png': 'moon',
        'cloudy.png': 'cloud',
        'cloudyn.png': 'cloud',
        'cloudyw.png': 'cloud',
        'cloudywn.png': 'cloud',
        'drizzle.png': 'cloudDrizzle',
        'drizzlef.png': 'cloudDrizzle',
        'drizzlen.png': 'cloudDrizzle',
        'dust.png': 'tornado',
        'fair.png': 'sun',
        'fairn.png': 'moon',
        'fairw.png': 'sun',
        'fairwn.png': 'moon',
        'fdrizzle.png': 'cloudDrizzle',
        'fdrizzlen.png': 'cloudDrizzle',
        'flurries.png': 'cloudSnowAlt',
        'flurriesn.png': 'cloudSnowAlt',
        'flurriesw.png': 'cloudSnowAlt',
        'flurrieswn.png': 'cloudSnowAlt',
        'fog.png': 'cloudFogSun',
        'fogn.png': 'cloudFogMoon',
        'freezingrain.png': 'cloudSnowSunAlt',
        'freezingrainn.png': 'cloudSnowMoonAlt', //TODO: cloudSnowAlt -> cloudSnowMoonAlt로 변경
        'hazy.png': 'cloudFogSunAlt',
        'hazyn.png': 'cloudFogMoonAlt',
        'mcloudy.png': 'cloudSun',
        'mcloudyn.png': 'cloudMoon',
        'mcloudyr.png': 'cloudDrizzleSun',
        'mcloudyrn.png': 'cloudDrizzleMoon',
        'mcloudyrw.png': 'cloudDrizzleSun',
        'mcloudyrwn.png': 'cloudDrizzleMoon',
        'mcloudys.png': 'cloudSnowSun',
        'mcloudysfn.png': 'cloudSnowMoon',
        'mcloudysfw.png': 'cloudSnowSun',
        'mcloudysfwn.png': 'cloudSnowMoon',
        'mcloudysn.png': 'cloudSnowMoon',
        'mcloudysw.png': 'cloudSnowSun',
        'mcloudyswn.png': 'cloudSnowMoon',
        'mcloudyt.png': 'cloudLightningSun',
        'mcloudytn.png': 'cloudLightningMoon',
        'mcloudytw.png': 'cloudLightningSun',
        'mcloudytwn.png': 'cloudLightningMoon',
        'mcloudyw.png': 'cloudSun',
        'mcloudywn.png': 'cloudMoon',
        'na.png': 'sunsetAlt',
        'pcloudy.png': 'cloudSun',
        'pcloudyn.png': 'cloudMoon',
        'pcloudyr.png': 'cloudDrizzleSun',
        'pcloudyrn.png': 'cloudDrizzleMoon',
        'pcloudyrw.png': 'cloudDrizzleSun',
        'pcloudyrwn.png': 'cloudDrizzleMoon',
        'pcloudys.png': 'cloudSnowSun',
        'pcloudysf.png': 'cloudSnowSun',
        'pcloudysfn.png': 'cloudSnowMoon',
        'pcloudysfw.png': 'cloudSnowSun',
        'pcloudysfwn.png': 'cloudSnowMoon',
        'pcloudysn.png': 'cloudSnowMoon',
        'pcloudysw.png': 'cloudSnowSun',
        'pcloudyswn.png': 'cloudSnowMoon',
        'pcloudyt.png': 'cloudLightningSun',
        'pcloudytn.png': 'cloudLightningMoon',
        'pcloudytw.png': 'cloudLightningSun',
        'pcloudytwn.png': 'cloudLightningMoon',
        'pcloudyw.png': 'cloudSun',
        'pcloudywn.png': 'cloudMoon',
        'pm_pcloudy.png': 'cloudSun',
        'pm_pcloudyr.png': 'cloudDrizzleSun',
        'pm_showers.png': 'cloudDrizzle',
        'pm_snowshowers.png': 'cloudSnow',
        'pm_tstorm.png': 'cloudLightningSun',
        'rain.png': 'cloudRain',
        'rainandsnow.png': 'cloudSnowAlt',
        'rainandsnown.png': 'cloudSnowAlt',
        'rainn.png': 'cloudRain',
        'raintosnow.png': 'cloudSnowAlt',
        'raintosnown.png': 'cloudSnowAlt',
        'rainw.png': 'cloudRain',
        'showers.png': 'cloudDrizzle',
        'showersn.png': 'cloudDrizzle',
        'showersw.png': 'cloudDrizzle',
        'sleet.png': 'cloudHailAlt',
        'sleetn.png': 'cloudHailAlt',
        'sleetsnow.png': 'cloudHailAlt',
        'smoke.png': 'cloudFogAlt',
        'snow.png': 'cloudSnow',
        'snown.png': 'cloudSnow',
        'snowshowers.png': 'cloudHailAlt',
        'snowshowersn.png': 'cloudHailAlt',
        'snowshowersw.png': 'cloudHailAlt',
        'snowshowerswn.png': 'cloudHailAlt',
        'snowtorain.png': 'cloudSnowAlt',
        'snowtorainn.png': 'cloudSnowAlt',
        'snoww.png': 'cloudSnow',
        'snowwn.png': 'cloudSnow',
        'sunny.png': 'sun',
        'sunnyn.png': 'moon',
        'sunnyw.png': 'sun',
        'sunnywn.png': 'moon',
        'tstorm.png': 'cloudLightning',
        'tstormn.png': 'cloudLightning',
        'tstormsw.png': 'cloudLightning',
        'tstormswn.png': 'cloudLightning',
        'wind.png': 'wind',
        'wintrymix.png': 'cloudHailAlt',
        'wintrymixn.png': 'cloudHailAlt'
    }
};

module.exports = CodedWeather;