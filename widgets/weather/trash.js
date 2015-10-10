$('.start').click(function () {
    $('.sun-animation').css('width', '72%');
    $('.sun-symbol-path').css('-webkit-transform', 'rotateZ(27deg)');
    // TODO: mention that this isn't nice
    // city.find('.sunmoon .sun-animation').css('-webkit-transform', 'scaleX(50)');
    return false;
});

$('.reset').click(function () {
    $('.sun-animation').css('width', '0%');
    $('.sun-symbol-path').css('-webkit-transform', 'rotateZ(-75deg)');
    return false;
});

/*

<section id="weather-list-component" class="weather-list" style="display: none;">
    <div class="weather-list-item">
    <div class="weather-list-item-day">
    <span weather-attr="weather-item-day" class="weather-list-item-day-day_of_week">오늘</span>
    <span weather-attr="weather-item-date" class="weather-list-item-day-date">10.1</span>
    </div>
    <div class="weather-list-item-temp">
    <span weather-attr="weather-item-highTemp" class="weather-list-item-temp-highTemp">19</span>
    <span class="weather-list-item-temp-division">&#47;</span>
<span weather-attr="weather-item-lowTemp" class="weather-list-item-temp-lowTemp">9</span>
    </div>
    <div class="weather-list-item-cond">
    <div weather-attr="weather-item-icon" class="weather-list-item-cond-icon">
    <svg version="1.1" class="climacon climacon_sun" viewBox="15 15 70 70">
    <clipPath id="sunFillClip">
    <path d="M0,0v100h100V0H0z M50.001,57.999c-4.417,0-8-3.582-8-7.999c0-4.418,3.582-7.999,8-7.999s7.998,3.581,7.998,7.999C57.999,54.417,54.418,57.999,50.001,57.999z" />
    </clipPath>
    <g class="climacon_iconWrap climacon_iconWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sunSpoke">
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-east" d="M72.03,51.999h-3.998c-1.105,0-2-0.896-2-1.999s0.895-2,2-2h3.998c1.104,0,2,0.896,2,2S73.136,51.999,72.03,51.999z" />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northEast" d="M64.175,38.688c-0.781,0.781-2.049,0.781-2.828,0c-0.781-0.781-0.781-2.047,0-2.828l2.828-2.828c0.779-0.781,2.047-0.781,2.828,0c0.779,0.781,0.779,2.047,0,2.828L64.175,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-north" d="M50.034,34.002c-1.105,0-2-0.896-2-2v-3.999c0-1.104,0.895-2,2-2c1.104,0,2,0.896,2,2v3.999C52.034,33.106,51.136,34.002,50.034,34.002z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northWest" d="M35.893,38.688l-2.827-2.828c-0.781-0.781-0.781-2.047,0-2.828c0.78-0.781,2.047-0.781,2.827,0l2.827,2.828c0.781,0.781,0.781,2.047,0,2.828C37.94,39.469,36.674,39.469,35.893,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-west" d="M34.034,50c0,1.104-0.896,1.999-2,1.999h-4c-1.104,0-1.998-0.896-1.998-1.999s0.896-2,1.998-2h4C33.14,48,34.034,48.896,34.034,50z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southWest" d="M35.893,61.312c0.781-0.78,2.048-0.78,2.827,0c0.781,0.78,0.781,2.047,0,2.828l-2.827,2.827c-0.78,0.781-2.047,0.781-2.827,0c-0.781-0.78-0.781-2.047,0-2.827L35.893,61.312z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-south" d="M50.034,65.998c1.104,0,2,0.895,2,1.999v4c0,1.104-0.896,2-2,2c-1.105,0-2-0.896-2-2v-4C48.034,66.893,48.929,65.998,50.034,65.998z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southEast" d="M64.175,61.312l2.828,2.828c0.779,0.78,0.779,2.047,0,2.827c-0.781,0.781-2.049,0.781-2.828,0l-2.828-2.827c-0.781-0.781-0.781-2.048,0-2.828C62.126,60.531,63.392,60.531,64.175,61.312z"
    />
    </g>
    <g class="climacon_componentWrap climacon_componentWrap_sunBody" clip-path="url(#sunFillClip)">
    <circle class="climacon_component climacon_component-stroke climacon_component-stroke_sunBody" cx="50.034" cy="50" r="11.999" />
    </g>
    </g>
    </g>
    </svg>
    </div>
    <span weather-attr="weather-item-description" class="weather-list-item-cond-description">Light Rain</span>
</div>
<div class="weather-list-item-precip">
    <i class="climacon umbrella"></i>
    <span class="weather-list-item-precip-description">50%</span>
    </div>
    <div class="weather-list-item-wind">
    <i class="climacon wind"></i>
    <span class="weather-list-item-wind-description">서쪽 26km/h</span>
</div>
</div>
<div class="weather-list-item">
    <div class="weather-list-item-day">
    <span weather-attr="weather-item-day" class="weather-list-item-day-day_of_week">오늘</span>
    <span weather-attr="weather-item-date" class="weather-list-item-day-date">10.1</span>
    </div>
    <div class="weather-list-item-temp">
    <span weather-attr="weather-item-highTemp" class="weather-list-item-temp-highTemp">19</span>
    <span class="weather-list-item-temp-division">&#47;</span>
<span weather-attr="weather-item-lowTemp" class="weather-list-item-temp-lowTemp">9</span>
    </div>
    <div class="weather-list-item-cond">
    <div weather-attr="weather-item-icon" class="weather-list-item-cond-icon">
    <svg version="1.1" class="climacon climacon_sun" viewBox="15 15 70 70">
    <clipPath id="sunFillClip">
    <path d="M0,0v100h100V0H0z M50.001,57.999c-4.417,0-8-3.582-8-7.999c0-4.418,3.582-7.999,8-7.999s7.998,3.581,7.998,7.999C57.999,54.417,54.418,57.999,50.001,57.999z" />
    </clipPath>
    <g class="climacon_iconWrap climacon_iconWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sunSpoke">
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-east" d="M72.03,51.999h-3.998c-1.105,0-2-0.896-2-1.999s0.895-2,2-2h3.998c1.104,0,2,0.896,2,2S73.136,51.999,72.03,51.999z" />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northEast" d="M64.175,38.688c-0.781,0.781-2.049,0.781-2.828,0c-0.781-0.781-0.781-2.047,0-2.828l2.828-2.828c0.779-0.781,2.047-0.781,2.828,0c0.779,0.781,0.779,2.047,0,2.828L64.175,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-north" d="M50.034,34.002c-1.105,0-2-0.896-2-2v-3.999c0-1.104,0.895-2,2-2c1.104,0,2,0.896,2,2v3.999C52.034,33.106,51.136,34.002,50.034,34.002z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northWest" d="M35.893,38.688l-2.827-2.828c-0.781-0.781-0.781-2.047,0-2.828c0.78-0.781,2.047-0.781,2.827,0l2.827,2.828c0.781,0.781,0.781,2.047,0,2.828C37.94,39.469,36.674,39.469,35.893,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-west" d="M34.034,50c0,1.104-0.896,1.999-2,1.999h-4c-1.104,0-1.998-0.896-1.998-1.999s0.896-2,1.998-2h4C33.14,48,34.034,48.896,34.034,50z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southWest" d="M35.893,61.312c0.781-0.78,2.048-0.78,2.827,0c0.781,0.78,0.781,2.047,0,2.828l-2.827,2.827c-0.78,0.781-2.047,0.781-2.827,0c-0.781-0.78-0.781-2.047,0-2.827L35.893,61.312z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-south" d="M50.034,65.998c1.104,0,2,0.895,2,1.999v4c0,1.104-0.896,2-2,2c-1.105,0-2-0.896-2-2v-4C48.034,66.893,48.929,65.998,50.034,65.998z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southEast" d="M64.175,61.312l2.828,2.828c0.779,0.78,0.779,2.047,0,2.827c-0.781,0.781-2.049,0.781-2.828,0l-2.828-2.827c-0.781-0.781-0.781-2.048,0-2.828C62.126,60.531,63.392,60.531,64.175,61.312z"
    />
    </g>
    <g class="climacon_componentWrap climacon_componentWrap_sunBody" clip-path="url(#sunFillClip)">
    <circle class="climacon_component climacon_component-stroke climacon_component-stroke_sunBody" cx="50.034" cy="50" r="11.999" />
    </g>
    </g>
    </g>
    </svg>
    </div>
    <span weather-attr="weather-item-description" class="weather-list-item-cond-description">Light Rain</span>
</div>
<div class="weather-list-item-precip">
    <i class="climacon umbrella"></i>
    <span class="weather-list-item-precip-description">50%</span>
    </div>
    <div class="weather-list-item-wind">
    <i class="climacon wind"></i>
    <span class="weather-list-item-wind-description">서쪽 26km/h</span>
</div>
</div>
<div class="weather-list-item">
    <div class="weather-list-item-day">
    <span weather-attr="weather-item-day" class="weather-list-item-day-day_of_week">오늘</span>
    <span weather-attr="weather-item-date" class="weather-list-item-day-date">10.1</span>
    </div>
    <div class="weather-list-item-temp">
    <span weather-attr="weather-item-highTemp" class="weather-list-item-temp-highTemp">19</span>
    <span class="weather-list-item-temp-division">&#47;</span>
<span weather-attr="weather-item-lowTemp" class="weather-list-item-temp-lowTemp">9</span>
    </div>
    <div class="weather-list-item-cond">
    <div weather-attr="weather-item-icon" class="weather-list-item-cond-icon">
    <svg version="1.1" class="climacon climacon_sun" viewBox="15 15 70 70">
    <clipPath id="sunFillClip">
    <path d="M0,0v100h100V0H0z M50.001,57.999c-4.417,0-8-3.582-8-7.999c0-4.418,3.582-7.999,8-7.999s7.998,3.581,7.998,7.999C57.999,54.417,54.418,57.999,50.001,57.999z" />
    </clipPath>
    <g class="climacon_iconWrap climacon_iconWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sunSpoke">
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-east" d="M72.03,51.999h-3.998c-1.105,0-2-0.896-2-1.999s0.895-2,2-2h3.998c1.104,0,2,0.896,2,2S73.136,51.999,72.03,51.999z" />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northEast" d="M64.175,38.688c-0.781,0.781-2.049,0.781-2.828,0c-0.781-0.781-0.781-2.047,0-2.828l2.828-2.828c0.779-0.781,2.047-0.781,2.828,0c0.779,0.781,0.779,2.047,0,2.828L64.175,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-north" d="M50.034,34.002c-1.105,0-2-0.896-2-2v-3.999c0-1.104,0.895-2,2-2c1.104,0,2,0.896,2,2v3.999C52.034,33.106,51.136,34.002,50.034,34.002z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northWest" d="M35.893,38.688l-2.827-2.828c-0.781-0.781-0.781-2.047,0-2.828c0.78-0.781,2.047-0.781,2.827,0l2.827,2.828c0.781,0.781,0.781,2.047,0,2.828C37.94,39.469,36.674,39.469,35.893,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-west" d="M34.034,50c0,1.104-0.896,1.999-2,1.999h-4c-1.104,0-1.998-0.896-1.998-1.999s0.896-2,1.998-2h4C33.14,48,34.034,48.896,34.034,50z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southWest" d="M35.893,61.312c0.781-0.78,2.048-0.78,2.827,0c0.781,0.78,0.781,2.047,0,2.828l-2.827,2.827c-0.78,0.781-2.047,0.781-2.827,0c-0.781-0.78-0.781-2.047,0-2.827L35.893,61.312z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-south" d="M50.034,65.998c1.104,0,2,0.895,2,1.999v4c0,1.104-0.896,2-2,2c-1.105,0-2-0.896-2-2v-4C48.034,66.893,48.929,65.998,50.034,65.998z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southEast" d="M64.175,61.312l2.828,2.828c0.779,0.78,0.779,2.047,0,2.827c-0.781,0.781-2.049,0.781-2.828,0l-2.828-2.827c-0.781-0.781-0.781-2.048,0-2.828C62.126,60.531,63.392,60.531,64.175,61.312z"
    />
    </g>
    <g class="climacon_componentWrap climacon_componentWrap_sunBody" clip-path="url(#sunFillClip)">
    <circle class="climacon_component climacon_component-stroke climacon_component-stroke_sunBody" cx="50.034" cy="50" r="11.999" />
    </g>
    </g>
    </g>
    </svg>
    </div>
    <span weather-attr="weather-item-description" class="weather-list-item-cond-description">Light Rain</span>
</div>
<div class="weather-list-item-precip">
    <i class="climacon umbrella"></i>
    <span class="weather-list-item-precip-description">50%</span>
    </div>
    <div class="weather-list-item-wind">
    <i class="climacon wind"></i>
    <span class="weather-list-item-wind-description">서쪽 26km/h</span>
</div>
</div>
<div class="weather-list-item">
    <div class="weather-list-item-day">
    <span weather-attr="weather-item-day" class="weather-list-item-day-day_of_week">오늘</span>
    <span weather-attr="weather-item-date" class="weather-list-item-day-date">10.1</span>
    </div>
    <div class="weather-list-item-temp">
    <span weather-attr="weather-item-highTemp" class="weather-list-item-temp-highTemp">19</span>
    <span class="weather-list-item-temp-division">&#47;</span>
<span weather-attr="weather-item-lowTemp" class="weather-list-item-temp-lowTemp">9</span>
    </div>
    <div class="weather-list-item-cond">
    <div weather-attr="weather-item-icon" class="weather-list-item-cond-icon">
    <svg version="1.1" class="climacon climacon_sun" viewBox="15 15 70 70">
    <clipPath id="sunFillClip">
    <path d="M0,0v100h100V0H0z M50.001,57.999c-4.417,0-8-3.582-8-7.999c0-4.418,3.582-7.999,8-7.999s7.998,3.581,7.998,7.999C57.999,54.417,54.418,57.999,50.001,57.999z" />
    </clipPath>
    <g class="climacon_iconWrap climacon_iconWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sunSpoke">
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-east" d="M72.03,51.999h-3.998c-1.105,0-2-0.896-2-1.999s0.895-2,2-2h3.998c1.104,0,2,0.896,2,2S73.136,51.999,72.03,51.999z" />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northEast" d="M64.175,38.688c-0.781,0.781-2.049,0.781-2.828,0c-0.781-0.781-0.781-2.047,0-2.828l2.828-2.828c0.779-0.781,2.047-0.781,2.828,0c0.779,0.781,0.779,2.047,0,2.828L64.175,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-north" d="M50.034,34.002c-1.105,0-2-0.896-2-2v-3.999c0-1.104,0.895-2,2-2c1.104,0,2,0.896,2,2v3.999C52.034,33.106,51.136,34.002,50.034,34.002z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northWest" d="M35.893,38.688l-2.827-2.828c-0.781-0.781-0.781-2.047,0-2.828c0.78-0.781,2.047-0.781,2.827,0l2.827,2.828c0.781,0.781,0.781,2.047,0,2.828C37.94,39.469,36.674,39.469,35.893,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-west" d="M34.034,50c0,1.104-0.896,1.999-2,1.999h-4c-1.104,0-1.998-0.896-1.998-1.999s0.896-2,1.998-2h4C33.14,48,34.034,48.896,34.034,50z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southWest" d="M35.893,61.312c0.781-0.78,2.048-0.78,2.827,0c0.781,0.78,0.781,2.047,0,2.828l-2.827,2.827c-0.78,0.781-2.047,0.781-2.827,0c-0.781-0.78-0.781-2.047,0-2.827L35.893,61.312z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-south" d="M50.034,65.998c1.104,0,2,0.895,2,1.999v4c0,1.104-0.896,2-2,2c-1.105,0-2-0.896-2-2v-4C48.034,66.893,48.929,65.998,50.034,65.998z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southEast" d="M64.175,61.312l2.828,2.828c0.779,0.78,0.779,2.047,0,2.827c-0.781,0.781-2.049,0.781-2.828,0l-2.828-2.827c-0.781-0.781-0.781-2.048,0-2.828C62.126,60.531,63.392,60.531,64.175,61.312z"
    />
    </g>
    <g class="climacon_componentWrap climacon_componentWrap_sunBody" clip-path="url(#sunFillClip)">
    <circle class="climacon_component climacon_component-stroke climacon_component-stroke_sunBody" cx="50.034" cy="50" r="11.999" />
    </g>
    </g>
    </g>
    </svg>
    </div>
    <span weather-attr="weather-item-description" class="weather-list-item-cond-description">Light Rain</span>
</div>
<div class="weather-list-item-precip">
    <i class="climacon umbrella"></i>
    <span class="weather-list-item-precip-description">50%</span>
    </div>
    <div class="weather-list-item-wind">
    <i class="climacon wind"></i>
    <span class="weather-list-item-wind-description">서쪽 26km/h</span>
</div>
</div>
<div class="weather-list-item">
    <div class="weather-list-item-day">
    <span weather-attr="weather-item-day" class="weather-list-item-day-day_of_week">오늘</span>
    <span weather-attr="weather-item-date" class="weather-list-item-day-date">10.1</span>
    </div>
    <div class="weather-list-item-temp">
    <span weather-attr="weather-item-highTemp" class="weather-list-item-temp-highTemp">19</span>
    <span class="weather-list-item-temp-division">&#47;</span>
<span weather-attr="weather-item-lowTemp" class="weather-list-item-temp-lowTemp">9</span>
    </div>
    <div class="weather-list-item-cond">
    <div weather-attr="weather-item-icon" class="weather-list-item-cond-icon">
    <svg version="1.1" class="climacon climacon_sun" viewBox="15 15 70 70">
    <clipPath id="sunFillClip">
    <path d="M0,0v100h100V0H0z M50.001,57.999c-4.417,0-8-3.582-8-7.999c0-4.418,3.582-7.999,8-7.999s7.998,3.581,7.998,7.999C57.999,54.417,54.418,57.999,50.001,57.999z" />
    </clipPath>
    <g class="climacon_iconWrap climacon_iconWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sunSpoke">
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-east" d="M72.03,51.999h-3.998c-1.105,0-2-0.896-2-1.999s0.895-2,2-2h3.998c1.104,0,2,0.896,2,2S73.136,51.999,72.03,51.999z" />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northEast" d="M64.175,38.688c-0.781,0.781-2.049,0.781-2.828,0c-0.781-0.781-0.781-2.047,0-2.828l2.828-2.828c0.779-0.781,2.047-0.781,2.828,0c0.779,0.781,0.779,2.047,0,2.828L64.175,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-north" d="M50.034,34.002c-1.105,0-2-0.896-2-2v-3.999c0-1.104,0.895-2,2-2c1.104,0,2,0.896,2,2v3.999C52.034,33.106,51.136,34.002,50.034,34.002z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northWest" d="M35.893,38.688l-2.827-2.828c-0.781-0.781-0.781-2.047,0-2.828c0.78-0.781,2.047-0.781,2.827,0l2.827,2.828c0.781,0.781,0.781,2.047,0,2.828C37.94,39.469,36.674,39.469,35.893,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-west" d="M34.034,50c0,1.104-0.896,1.999-2,1.999h-4c-1.104,0-1.998-0.896-1.998-1.999s0.896-2,1.998-2h4C33.14,48,34.034,48.896,34.034,50z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southWest" d="M35.893,61.312c0.781-0.78,2.048-0.78,2.827,0c0.781,0.78,0.781,2.047,0,2.828l-2.827,2.827c-0.78,0.781-2.047,0.781-2.827,0c-0.781-0.78-0.781-2.047,0-2.827L35.893,61.312z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-south" d="M50.034,65.998c1.104,0,2,0.895,2,1.999v4c0,1.104-0.896,2-2,2c-1.105,0-2-0.896-2-2v-4C48.034,66.893,48.929,65.998,50.034,65.998z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southEast" d="M64.175,61.312l2.828,2.828c0.779,0.78,0.779,2.047,0,2.827c-0.781,0.781-2.049,0.781-2.828,0l-2.828-2.827c-0.781-0.781-0.781-2.048,0-2.828C62.126,60.531,63.392,60.531,64.175,61.312z"
    />
    </g>
    <g class="climacon_componentWrap climacon_componentWrap_sunBody" clip-path="url(#sunFillClip)">
    <circle class="climacon_component climacon_component-stroke climacon_component-stroke_sunBody" cx="50.034" cy="50" r="11.999" />
    </g>
    </g>
    </g>
    </svg>
    </div>
    <span weather-attr="weather-item-description" class="weather-list-item-cond-description">Light Rain</span>
</div>
<div class="weather-list-item-precip">
    <i class="climacon umbrella"></i>
    <span class="weather-list-item-precip-description">50%</span>
    </div>
    <div class="weather-list-item-wind">
    <i class="climacon wind"></i>
    <span class="weather-list-item-wind-description">서쪽 26km/h</span>
</div>
</div>
<div class="weather-list-item">
    <div class="weather-list-item-day">
    <span weather-attr="weather-item-day" class="weather-list-item-day-day_of_week">오늘</span>
    <span weather-attr="weather-item-date" class="weather-list-item-day-date">10.1</span>
    </div>
    <div class="weather-list-item-temp">
    <span weather-attr="weather-item-highTemp" class="weather-list-item-temp-highTemp">19</span>
    <span class="weather-list-item-temp-division">&#47;</span>
<span weather-attr="weather-item-lowTemp" class="weather-list-item-temp-lowTemp">9</span>
    </div>
    <div class="weather-list-item-cond">
    <div weather-attr="weather-item-icon" class="weather-list-item-cond-icon">
    <svg version="1.1" class="climacon climacon_sun" viewBox="15 15 70 70">
    <clipPath id="sunFillClip">
    <path d="M0,0v100h100V0H0z M50.001,57.999c-4.417,0-8-3.582-8-7.999c0-4.418,3.582-7.999,8-7.999s7.998,3.581,7.998,7.999C57.999,54.417,54.418,57.999,50.001,57.999z" />
    </clipPath>
    <g class="climacon_iconWrap climacon_iconWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sunSpoke">
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-east" d="M72.03,51.999h-3.998c-1.105,0-2-0.896-2-1.999s0.895-2,2-2h3.998c1.104,0,2,0.896,2,2S73.136,51.999,72.03,51.999z" />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northEast" d="M64.175,38.688c-0.781,0.781-2.049,0.781-2.828,0c-0.781-0.781-0.781-2.047,0-2.828l2.828-2.828c0.779-0.781,2.047-0.781,2.828,0c0.779,0.781,0.779,2.047,0,2.828L64.175,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-north" d="M50.034,34.002c-1.105,0-2-0.896-2-2v-3.999c0-1.104,0.895-2,2-2c1.104,0,2,0.896,2,2v3.999C52.034,33.106,51.136,34.002,50.034,34.002z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northWest" d="M35.893,38.688l-2.827-2.828c-0.781-0.781-0.781-2.047,0-2.828c0.78-0.781,2.047-0.781,2.827,0l2.827,2.828c0.781,0.781,0.781,2.047,0,2.828C37.94,39.469,36.674,39.469,35.893,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-west" d="M34.034,50c0,1.104-0.896,1.999-2,1.999h-4c-1.104,0-1.998-0.896-1.998-1.999s0.896-2,1.998-2h4C33.14,48,34.034,48.896,34.034,50z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southWest" d="M35.893,61.312c0.781-0.78,2.048-0.78,2.827,0c0.781,0.78,0.781,2.047,0,2.828l-2.827,2.827c-0.78,0.781-2.047,0.781-2.827,0c-0.781-0.78-0.781-2.047,0-2.827L35.893,61.312z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-south" d="M50.034,65.998c1.104,0,2,0.895,2,1.999v4c0,1.104-0.896,2-2,2c-1.105,0-2-0.896-2-2v-4C48.034,66.893,48.929,65.998,50.034,65.998z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southEast" d="M64.175,61.312l2.828,2.828c0.779,0.78,0.779,2.047,0,2.827c-0.781,0.781-2.049,0.781-2.828,0l-2.828-2.827c-0.781-0.781-0.781-2.048,0-2.828C62.126,60.531,63.392,60.531,64.175,61.312z"
    />
    </g>
    <g class="climacon_componentWrap climacon_componentWrap_sunBody" clip-path="url(#sunFillClip)">
    <circle class="climacon_component climacon_component-stroke climacon_component-stroke_sunBody" cx="50.034" cy="50" r="11.999" />
    </g>
    </g>
    </g>
    </svg>
    </div>
    <span weather-attr="weather-item-description" class="weather-list-item-cond-description">Light Rain</span>
</div>
<div class="weather-list-item-precip">
    <i class="climacon umbrella"></i>
    <span class="weather-list-item-precip-description">50%</span>
    </div>
    <div class="weather-list-item-wind">
    <i class="climacon wind"></i>
    <span class="weather-list-item-wind-description">서쪽 26km/h</span>
</div>
</div>
<div class="weather-list-item">
    <div class="weather-list-item-day">
    <span weather-attr="weather-item-day" class="weather-list-item-day-day_of_week">오늘</span>
    <span weather-attr="weather-item-date" class="weather-list-item-day-date">10.1</span>
    </div>
    <div class="weather-list-item-temp">
    <span weather-attr="weather-item-highTemp" class="weather-list-item-temp-highTemp">19</span>
    <span class="weather-list-item-temp-division">&#47;</span>
<span weather-attr="weather-item-lowTemp" class="weather-list-item-temp-lowTemp">9</span>
    </div>
    <div class="weather-list-item-cond">
    <div weather-attr="weather-item-icon" class="weather-list-item-cond-icon">
    <svg version="1.1" class="climacon climacon_sun" viewBox="15 15 70 70">
    <clipPath id="sunFillClip">
    <path d="M0,0v100h100V0H0z M50.001,57.999c-4.417,0-8-3.582-8-7.999c0-4.418,3.582-7.999,8-7.999s7.998,3.581,7.998,7.999C57.999,54.417,54.418,57.999,50.001,57.999z" />
    </clipPath>
    <g class="climacon_iconWrap climacon_iconWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sunSpoke">
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-east" d="M72.03,51.999h-3.998c-1.105,0-2-0.896-2-1.999s0.895-2,2-2h3.998c1.104,0,2,0.896,2,2S73.136,51.999,72.03,51.999z" />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northEast" d="M64.175,38.688c-0.781,0.781-2.049,0.781-2.828,0c-0.781-0.781-0.781-2.047,0-2.828l2.828-2.828c0.779-0.781,2.047-0.781,2.828,0c0.779,0.781,0.779,2.047,0,2.828L64.175,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-north" d="M50.034,34.002c-1.105,0-2-0.896-2-2v-3.999c0-1.104,0.895-2,2-2c1.104,0,2,0.896,2,2v3.999C52.034,33.106,51.136,34.002,50.034,34.002z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northWest" d="M35.893,38.688l-2.827-2.828c-0.781-0.781-0.781-2.047,0-2.828c0.78-0.781,2.047-0.781,2.827,0l2.827,2.828c0.781,0.781,0.781,2.047,0,2.828C37.94,39.469,36.674,39.469,35.893,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-west" d="M34.034,50c0,1.104-0.896,1.999-2,1.999h-4c-1.104,0-1.998-0.896-1.998-1.999s0.896-2,1.998-2h4C33.14,48,34.034,48.896,34.034,50z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southWest" d="M35.893,61.312c0.781-0.78,2.048-0.78,2.827,0c0.781,0.78,0.781,2.047,0,2.828l-2.827,2.827c-0.78,0.781-2.047,0.781-2.827,0c-0.781-0.78-0.781-2.047,0-2.827L35.893,61.312z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-south" d="M50.034,65.998c1.104,0,2,0.895,2,1.999v4c0,1.104-0.896,2-2,2c-1.105,0-2-0.896-2-2v-4C48.034,66.893,48.929,65.998,50.034,65.998z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southEast" d="M64.175,61.312l2.828,2.828c0.779,0.78,0.779,2.047,0,2.827c-0.781,0.781-2.049,0.781-2.828,0l-2.828-2.827c-0.781-0.781-0.781-2.048,0-2.828C62.126,60.531,63.392,60.531,64.175,61.312z"
    />
    </g>
    <g class="climacon_componentWrap climacon_componentWrap_sunBody" clip-path="url(#sunFillClip)">
    <circle class="climacon_component climacon_component-stroke climacon_component-stroke_sunBody" cx="50.034" cy="50" r="11.999" />
    </g>
    </g>
    </g>
    </svg>
    </div>
    <span weather-attr="weather-item-description" class="weather-list-item-cond-description">Light Rain</span>
</div>
<div class="weather-list-item-precip">
    <i class="climacon umbrella"></i>
    <span class="weather-list-item-precip-description">50%</span>
    </div>
    <div class="weather-list-item-wind">
    <i class="climacon wind"></i>
    <span class="weather-list-item-wind-description">서쪽 26km/h</span>
</div>
</div>
<div class="weather-list-item">
    <div class="weather-list-item-day">
    <span weather-attr="weather-item-day" class="weather-list-item-day-day_of_week">오늘</span>
    <span weather-attr="weather-item-date" class="weather-list-item-day-date">10.1</span>
    </div>
    <div class="weather-list-item-temp">
    <span weather-attr="weather-item-highTemp" class="weather-list-item-temp-highTemp">19</span>
    <span class="weather-list-item-temp-division">&#47;</span>
<span weather-attr="weather-item-lowTemp" class="weather-list-item-temp-lowTemp">9</span>
    </div>
    <div class="weather-list-item-cond">
    <div weather-attr="weather-item-icon" class="weather-list-item-cond-icon">
    <svg version="1.1" class="climacon climacon_sun" viewBox="15 15 70 70">
    <clipPath id="sunFillClip">
    <path d="M0,0v100h100V0H0z M50.001,57.999c-4.417,0-8-3.582-8-7.999c0-4.418,3.582-7.999,8-7.999s7.998,3.581,7.998,7.999C57.999,54.417,54.418,57.999,50.001,57.999z" />
    </clipPath>
    <g class="climacon_iconWrap climacon_iconWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sunSpoke">
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-east" d="M72.03,51.999h-3.998c-1.105,0-2-0.896-2-1.999s0.895-2,2-2h3.998c1.104,0,2,0.896,2,2S73.136,51.999,72.03,51.999z" />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northEast" d="M64.175,38.688c-0.781,0.781-2.049,0.781-2.828,0c-0.781-0.781-0.781-2.047,0-2.828l2.828-2.828c0.779-0.781,2.047-0.781,2.828,0c0.779,0.781,0.779,2.047,0,2.828L64.175,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-north" d="M50.034,34.002c-1.105,0-2-0.896-2-2v-3.999c0-1.104,0.895-2,2-2c1.104,0,2,0.896,2,2v3.999C52.034,33.106,51.136,34.002,50.034,34.002z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northWest" d="M35.893,38.688l-2.827-2.828c-0.781-0.781-0.781-2.047,0-2.828c0.78-0.781,2.047-0.781,2.827,0l2.827,2.828c0.781,0.781,0.781,2.047,0,2.828C37.94,39.469,36.674,39.469,35.893,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-west" d="M34.034,50c0,1.104-0.896,1.999-2,1.999h-4c-1.104,0-1.998-0.896-1.998-1.999s0.896-2,1.998-2h4C33.14,48,34.034,48.896,34.034,50z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southWest" d="M35.893,61.312c0.781-0.78,2.048-0.78,2.827,0c0.781,0.78,0.781,2.047,0,2.828l-2.827,2.827c-0.78,0.781-2.047,0.781-2.827,0c-0.781-0.78-0.781-2.047,0-2.827L35.893,61.312z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-south" d="M50.034,65.998c1.104,0,2,0.895,2,1.999v4c0,1.104-0.896,2-2,2c-1.105,0-2-0.896-2-2v-4C48.034,66.893,48.929,65.998,50.034,65.998z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southEast" d="M64.175,61.312l2.828,2.828c0.779,0.78,0.779,2.047,0,2.827c-0.781,0.781-2.049,0.781-2.828,0l-2.828-2.827c-0.781-0.781-0.781-2.048,0-2.828C62.126,60.531,63.392,60.531,64.175,61.312z"
    />
    </g>
    <g class="climacon_componentWrap climacon_componentWrap_sunBody" clip-path="url(#sunFillClip)">
    <circle class="climacon_component climacon_component-stroke climacon_component-stroke_sunBody" cx="50.034" cy="50" r="11.999" />
    </g>
    </g>
    </g>
    </svg>
    </div>
    <span weather-attr="weather-item-description" class="weather-list-item-cond-description">Light Rain</span>
</div>
<div class="weather-list-item-precip">
    <i class="climacon umbrella"></i>
    <span class="weather-list-item-precip-description">50%</span>
    </div>
    <div class="weather-list-item-wind">
    <i class="climacon wind"></i>
    <span class="weather-list-item-wind-description">서쪽 26km/h</span>
</div>
</div>
<div class="weather-list-item">
    <div class="weather-list-item-day">
    <span weather-attr="weather-item-day" class="weather-list-item-day-day_of_week">오늘</span>
    <span weather-attr="weather-item-date" class="weather-list-item-day-date">10.1</span>
    </div>
    <div class="weather-list-item-temp">
    <span weather-attr="weather-item-highTemp" class="weather-list-item-temp-highTemp">19</span>
    <span class="weather-list-item-temp-division">&#47;</span>
<span weather-attr="weather-item-lowTemp" class="weather-list-item-temp-lowTemp">9</span>
    </div>
    <div class="weather-list-item-cond">
    <div weather-attr="weather-item-icon" class="weather-list-item-cond-icon">
    <svg version="1.1" class="climacon climacon_sun" viewBox="15 15 70 70">
    <clipPath id="sunFillClip">
    <path d="M0,0v100h100V0H0z M50.001,57.999c-4.417,0-8-3.582-8-7.999c0-4.418,3.582-7.999,8-7.999s7.998,3.581,7.998,7.999C57.999,54.417,54.418,57.999,50.001,57.999z" />
    </clipPath>
    <g class="climacon_iconWrap climacon_iconWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sunSpoke">
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-east" d="M72.03,51.999h-3.998c-1.105,0-2-0.896-2-1.999s0.895-2,2-2h3.998c1.104,0,2,0.896,2,2S73.136,51.999,72.03,51.999z" />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northEast" d="M64.175,38.688c-0.781,0.781-2.049,0.781-2.828,0c-0.781-0.781-0.781-2.047,0-2.828l2.828-2.828c0.779-0.781,2.047-0.781,2.828,0c0.779,0.781,0.779,2.047,0,2.828L64.175,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-north" d="M50.034,34.002c-1.105,0-2-0.896-2-2v-3.999c0-1.104,0.895-2,2-2c1.104,0,2,0.896,2,2v3.999C52.034,33.106,51.136,34.002,50.034,34.002z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northWest" d="M35.893,38.688l-2.827-2.828c-0.781-0.781-0.781-2.047,0-2.828c0.78-0.781,2.047-0.781,2.827,0l2.827,2.828c0.781,0.781,0.781,2.047,0,2.828C37.94,39.469,36.674,39.469,35.893,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-west" d="M34.034,50c0,1.104-0.896,1.999-2,1.999h-4c-1.104,0-1.998-0.896-1.998-1.999s0.896-2,1.998-2h4C33.14,48,34.034,48.896,34.034,50z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southWest" d="M35.893,61.312c0.781-0.78,2.048-0.78,2.827,0c0.781,0.78,0.781,2.047,0,2.828l-2.827,2.827c-0.78,0.781-2.047,0.781-2.827,0c-0.781-0.78-0.781-2.047,0-2.827L35.893,61.312z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-south" d="M50.034,65.998c1.104,0,2,0.895,2,1.999v4c0,1.104-0.896,2-2,2c-1.105,0-2-0.896-2-2v-4C48.034,66.893,48.929,65.998,50.034,65.998z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southEast" d="M64.175,61.312l2.828,2.828c0.779,0.78,0.779,2.047,0,2.827c-0.781,0.781-2.049,0.781-2.828,0l-2.828-2.827c-0.781-0.781-0.781-2.048,0-2.828C62.126,60.531,63.392,60.531,64.175,61.312z"
    />
    </g>
    <g class="climacon_componentWrap climacon_componentWrap_sunBody" clip-path="url(#sunFillClip)">
    <circle class="climacon_component climacon_component-stroke climacon_component-stroke_sunBody" cx="50.034" cy="50" r="11.999" />
    </g>
    </g>
    </g>
    </svg>
    </div>
    <span weather-attr="weather-item-description" class="weather-list-item-cond-description">Light Rain</span>
</div>
<div class="weather-list-item-precip">
    <i class="climacon umbrella"></i>
    <span class="weather-list-item-precip-description">50%</span>
    </div>
    <div class="weather-list-item-wind">
    <i class="climacon wind"></i>
    <span class="weather-list-item-wind-description">서쪽 26km/h</span>
</div>
</div>
<div class="weather-list-item">
    <div class="weather-list-item-day">
    <span weather-attr="weather-item-day" class="weather-list-item-day-day_of_week">오늘</span>
    <span weather-attr="weather-item-date" class="weather-list-item-day-date">10.1</span>
    </div>
    <div class="weather-list-item-temp">
    <span weather-attr="weather-item-highTemp" class="weather-list-item-temp-highTemp">19</span>
    <span class="weather-list-item-temp-division">&#47;</span>
<span weather-attr="weather-item-lowTemp" class="weather-list-item-temp-lowTemp">9</span>
    </div>
    <div class="weather-list-item-cond">
    <div weather-attr="weather-item-icon" class="weather-list-item-cond-icon">
    <svg version="1.1" class="climacon climacon_sun" viewBox="15 15 70 70">
    <clipPath id="sunFillClip">
    <path d="M0,0v100h100V0H0z M50.001,57.999c-4.417,0-8-3.582-8-7.999c0-4.418,3.582-7.999,8-7.999s7.998,3.581,7.998,7.999C57.999,54.417,54.418,57.999,50.001,57.999z" />
    </clipPath>
    <g class="climacon_iconWrap climacon_iconWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sun">
    <g class="climacon_componentWrap climacon_componentWrap-sunSpoke">
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-east" d="M72.03,51.999h-3.998c-1.105,0-2-0.896-2-1.999s0.895-2,2-2h3.998c1.104,0,2,0.896,2,2S73.136,51.999,72.03,51.999z" />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northEast" d="M64.175,38.688c-0.781,0.781-2.049,0.781-2.828,0c-0.781-0.781-0.781-2.047,0-2.828l2.828-2.828c0.779-0.781,2.047-0.781,2.828,0c0.779,0.781,0.779,2.047,0,2.828L64.175,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-north" d="M50.034,34.002c-1.105,0-2-0.896-2-2v-3.999c0-1.104,0.895-2,2-2c1.104,0,2,0.896,2,2v3.999C52.034,33.106,51.136,34.002,50.034,34.002z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-northWest" d="M35.893,38.688l-2.827-2.828c-0.781-0.781-0.781-2.047,0-2.828c0.78-0.781,2.047-0.781,2.827,0l2.827,2.828c0.781,0.781,0.781,2.047,0,2.828C37.94,39.469,36.674,39.469,35.893,38.688z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-west" d="M34.034,50c0,1.104-0.896,1.999-2,1.999h-4c-1.104,0-1.998-0.896-1.998-1.999s0.896-2,1.998-2h4C33.14,48,34.034,48.896,34.034,50z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southWest" d="M35.893,61.312c0.781-0.78,2.048-0.78,2.827,0c0.781,0.78,0.781,2.047,0,2.828l-2.827,2.827c-0.78,0.781-2.047,0.781-2.827,0c-0.781-0.78-0.781-2.047,0-2.827L35.893,61.312z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-south" d="M50.034,65.998c1.104,0,2,0.895,2,1.999v4c0,1.104-0.896,2-2,2c-1.105,0-2-0.896-2-2v-4C48.034,66.893,48.929,65.998,50.034,65.998z"
    />
    <path class="climacon_component climacon_component-stroke climacon_component-stroke_sunSpoke climacon_component-stroke_sunSpoke-southEast" d="M64.175,61.312l2.828,2.828c0.779,0.78,0.779,2.047,0,2.827c-0.781,0.781-2.049,0.781-2.828,0l-2.828-2.827c-0.781-0.781-0.781-2.048,0-2.828C62.126,60.531,63.392,60.531,64.175,61.312z"
    />
    </g>
    <g class="climacon_componentWrap climacon_componentWrap_sunBody" clip-path="url(#sunFillClip)">
    <circle class="climacon_component climacon_component-stroke climacon_component-stroke_sunBody" cx="50.034" cy="50" r="11.999" />
    </g>
    </g>
    </g>
    </svg>
    </div>
    <span weather-attr="weather-item-description" class="weather-list-item-cond-description">Light Rain</span>
</div>
<div class="weather-list-item-precip">
    <i class="climacon umbrella"></i>
    <span class="weather-list-item-precip-description">50%</span>
    </div>
    <div class="weather-list-item-wind">
    <i class="climacon wind"></i>
    <span class="weather-list-item-wind-description">서쪽 26km/h</span>
</div>
</div>
</section>

    */


/*
 var WeatherConditionConstants = {
 '200': {
 'day-id': 'thunder',
 'night-id': 'thunder',
 description: 'thunderstorm with light rain'
 },
 '201': {
 'day-id': 'thunder',
 'night-id': 'thunder',
 description: 'thunderstorm with rain'
 },
 '202': {
 'day-id': 'thunder',
 'night-id': 'thunder',
 description: 'thunderstorm with heavy rain'
 },
 '210': {
 'day-id': 'thunder',
 'night-id': 'thunder',
 description: 'light thunderstorm'
 },
 '211': {
 'day-id': 'thunder',
 'night-id': 'thunder',
 description: 'thunderstorm'
 },
 '212': {
 'day-id': 'thunder',
 'night-id': 'thunder',
 description: 'heavy thunderstorm'
 },
 '221': {
 'day-id': 'thunder',
 'night-id': 'thunder',
 description: 'ragged thunderstorm'
 },
 '230': {
 'day-id': 'thunder',
 'night-id': 'thunder',
 description: 'thunderstorm with light drizzle'
 },
 '231': {
 'day-id': 'thunder',
 'night-id': 'thunder',
 description: 'thunderstorm with drizzle'
 },
 '232': {
 'day-id': 'thunder',
 'night-id': 'thunder',
 description: 'thunderstorm with heavy drizzle'
 },





 '300': {
 'day-id': 'cloudDrizzleAlt',
 'night-id': 'cloudDrizzleAlt',
 description: 'light intensity drizzle'
 },
 '301': {
 'day-id': 'cloudDrizzleAlt',
 'night-id': 'cloudDrizzleAlt',
 description: 'drizzle'
 },
 '302': {
 'day-id': 'cloudDrizzleAlt',
 'night-id': 'cloudDrizzleAlt',
 description: 'heavy intensity drizzle'
 },
 '310': {
 'day-id': 'cloudDrizzleAlt',
 'night-id': 'cloudDrizzleAlt',
 description: 'light intensity drizzle rain'
 },
 '311': {
 'day-id': 'cloudDrizzleAlt',
 'night-id': 'cloudDrizzleAlt',
 description: 'drizzle rain'
 },
 '312': {
 'day-id': 'cloudDrizzleAlt',
 'night-id': 'cloudDrizzleAlt',
 description: 'heavy intensity drizzle rain'
 },
 '313': {
 'day-id': 'cloudDrizzleAlt',
 'night-id': 'cloudDrizzleAlt',
 description: 'shower rain and drizzle'
 },
 '314': {
 'day-id': 'cloudDrizzleAlt',
 'night-id': 'cloudDrizzleAlt',
 description: 'heavy shower rain and drizzle'
 },
 '321': {
 'day-id': 'cloudDrizzleAlt',
 'night-id': 'cloudDrizzleAlt',
 description: 'shower drizzle'
 },





 '500': {
 'day-id': 'cloudDrizzleSun',
 'night-id': 'cloudDrizzleMoon',
 description: 'light rain'
 },
 '501': {
 'day-id': 'cloudDrizzleSun',
 'night-id': 'cloudDrizzleMoon',
 description: 'moderate rain'
 },
 '502': {
 'day-id': 'cloudDrizzleSun',
 'night-id': 'cloudDrizzleMoon',
 description: 'heavy intensity rain'
 },
 '503': {
 'day-id': 'cloudDrizzleSun',
 'night-id': 'cloudDrizzleMoon',
 description: 'very heavy rain'
 },
 '504': {
 'day-id': 'cloudDrizzleSun',
 'night-id': 'cloudDrizzleMoon',
 description: 'extreme rain'
 },
 '511': {
 'day-id': 'cloudSnowSunAlt',
 'night-id': 'cloudSnowAlt',
 description: 'freezing rain'
 },
 '520': {
 'day-id': 'cloudRain',
 'night-id': 'cloudRain',
 description: 'light intensity shower rain'
 },
 '521': {
 'day-id': 'cloudRain',
 'night-id': 'cloudRain',
 description: 'shower rain'
 },
 '522': {
 'day-id': 'cloudRain',
 'night-id': 'cloudRain',
 description: 'heavy intensity shower rain'
 },
 '531': {
 'day-id': 'cloudRain',
 'night-id': 'cloudRain',
 description: 'ragged shower rain'
 },




 '600': {
 'day-id': 'cloudSnow',
 'night-id': 'cloudSnow',
 description: 'light snow'
 },
 '601': {
 'day-id': 'cloudSnow',
 'night-id': 'cloudSnow',
 description: 'snow'
 },
 '602': {
 'day-id': 'cloudSnow',
 'night-id': 'cloudSnow',
 description: 'heavy snow'
 },
 '611': {
 'day-id': 'cloudSnow',
 'night-id': 'cloudSnow',
 description: 'sleet'
 },
 '612': {
 'day-id': 'cloudSnow',
 'night-id': 'cloudSnow',
 description: 'shower sleet'
 },
 '615': {
 'day-id': 'cloudSnow',
 'night-id': 'cloudSnow',
 description: 'light rain and snow'
 },
 '616': {
 'day-id': 'cloudSnow',
 'night-id': 'cloudSnow',
 description: 'rain and snow'
 },
 '620': {
 'day-id': 'cloudSnow',
 'night-id': 'cloudSnow',
 description: 'light shower snow'
 },
 '621': {
 'day-id': 'cloudSnow',
 'night-id': 'cloudSnow',
 description: 'shower snow'
 },
 '622': {
 'day-id': 'cloudSnow',
 'night-id': 'cloudSnow',
 description: 'heavy shower snow'
 },




 '701': {
 'day-id': 'cloudFogSun',
 'night-id': 'cloudFogMoon',
 description: 'mist'
 },
 '711': {
 'day-id': 'cloudFogSun',
 'night-id': 'cloudFogMoon',
 description: 'smoke'
 },
 '721': {
 'day-id': 'cloudFog',
 'night-id': 'cloudFog',
 description: 'haze'
 },
 '731': {
 'day-id': 'tornado',
 'night-id': 'tornado',
 description: 'sand, dust whirls'
 },
 '741': {
 'day-id': 'cloudFogSun',
 'night-id': 'cloudFogMoon',
 description: 'fog'
 },
 '751': {
 'day-id': 'tornado',
 'night-id': 'tornado',
 description: 'sand'
 },
 '761': {
 'day-id': 'tornado',
 'night-id': 'tornado',
 description: 'dust'
 },
 '762': {
 'day-id': 'cloudFog',
 'night-id': 'cloudFog',
 description: 'volcanic ash'
 },
 '771': {
 'day-id': 'tornado',
 'night-id': 'tornado',
 description: 'squalls'
 },
 '781': {
 'day-id': 'tornado',
 'night-id': 'tornado',
 description: 'tornado'
 },




 '800': {
 'day-id': 'sun',
 'night-id': 'moon',
 description: 'clear sky'
 },
 '801': {
 'day-id': 'cloudSun',
 'night-id': 'cloudMoon',
 description: 'few clouds'
 },
 '802': {
 'day-id': 'cloud',
 'night-id': 'cloud',
 description: 'scattered clouds'
 },
 '803': {
 'day-id': 'cloud',
 'night-id': 'cloudMoon',
 description: 'broken clouds'
 },
 '804': {
 'day-id': 'cloud',
 'night-id': 'cloud',
 description: 'overcast clouds'
 }
 };

 module.exports = WeatherConditionConstants;
 */