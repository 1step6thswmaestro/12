# Lumino
Team. **JARVIS**

* **멘티**
	* 박인범 (팀장, [nulledge@naver.com](mailTo:nulledge@naver.com), [Facebook](https://www.facebook.com/inbum.park.58))
	* 소현섭 ([iodesme@gmail.com](mailTo:iodesme@gmail.com), [Facebook](https://www.facebook.com/profile.php?id=100009172387549))
	* 나석주 ([seokmaTD@gmail.com](mailTo:seokmaTD@gmail.com), [Facebook](https://www.facebook.com/seokma))
* **멘토**
	* 김종광 ([kim@jongkwang.com](mailTo:kim@jongkwang.com), [Facebook](https://www.facebook.com/kimjongkwang))


## 소개
* Lumino는 **Mirror TV를 위한 .NET 기반의 플랫폼**입니다.
* 하드웨어 부분은 [Smart Mirror](https://www.kickstarter.com/projects/513673859/smartmirror)와 [Raspberry Pi Magic Mirror](http://michaelteeuw.nl/post/84026273526/and-there-it-is-the-end-result-of-the-magic)로부터 많은 참고를 하였습니다.


## 설치 및 실행
해당 프로젝트는 .NET 기반에서 실행이 됩니다.


## 가이드
#### 1. Mirror TV 제작
TV 디스플레이와 반투명 거울(half-mirror)을 준비합니다.  
반투명 거울은 다음 링크에서 구매가 가능합니다.

* [http://www.atoptronics.com/](http://www.atoptronics.com/)
* [http://mirrortv.nemocom.kr/sub/sub0101.php](http://mirrortv.nemocom.kr/sub/sub0101.php)
* [http://www.atostore.com/index.html](http://www.atostore.com/index.html)
* [http://www.twowaymirrors.com/tvmirror/](http://www.twowaymirrors.com/tvmirror/)

TV 디스플레이에 알맞게 거울을 재단한 후, 거울을 TV 디스플레이에 접합합니다.

#### 2. 미니PC 및 Raspberry PI 설치
적당한 크기와 성능의 미니PC와 라즈베리 파이를 준비한 후 TV에 연결합니다.
이때 라즈베리 파이는 반드시 HDMI로 TV와 연결되도록 합니다.
libcec가 지원하는 브랜드의 TV여야 합니다.

#### 3. Raspberry PI 센서 연결
라즈베리 파이에 인체감지 센서를 연결합니다. 사람을 감지할 수 있도록 적절한 위치에 센서를 부착합니다.
프로토타입에 사용한 제품은 다음과 같습니다.

* [PIR 인체감지 센서](http://www.artrobot.co.kr/front/php/product.php?product_no=757&main_cate_no=&display_group=)

#### 4. Lumino 플랫폼 탑재 및 실행


## 문서
주요 문서

* [코어 (Core)](https://github.com/1step6thswmaestro/12/blob/master/docs/Core.md)
* [캘린더 위젯 (Calendar Widget)](https://github.com/1step6thswmaestro/12/blob/master/docs/CalendarWidget.md)
* [시계 위젯 (Clock Widget)](https://github.com/1step6thswmaestro/12/blob/master/docs/ClockWidget.md)
* [갤러리 위젯 (Gallery Widget)](https://github.com/1step6thswmaestro/12/blob/master/docs/GalleryWidget.md)
* [날씨 위젯 (Weather Widget)](https://github.com/1step6thswmaestro/12/blob/master/docs/WeatherWidget.md)
* [음악 위젯 (Music Widget)](https://github.com/1step6thswmaestro/12/blob/master/docs/MusicWidget.md)
* [하드웨어 관련 (Hardwares)](https://github.com/1step6thswmaestro/12/blob/master/docs/Hardware.md)
* 참조 API (API Reference)

기타 문서

* [FlowingJS Document](https://github.com/1step6thswmaestro/12/tree/master/widgets/weather/libs)


## 라이센스
MIT Licnese
