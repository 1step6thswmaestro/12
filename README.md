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
### 하드웨어
#### 1. Mirror TV 제작
TV 디스플레이와 반투명 거울(Half-Mirror)을 준비합니다.  
반투명 거울은 다음 링크에서 구매가 가능합니다.

* [에이티옵트로닉스](http://www.atoptronics.com/)
* [거울 TV](http://mirrortv.nemocom.kr/sub/sub0101.php)
* [ATOStore](http://www.atostore.com/index.html)
* [Two Way Mirrors](http://www.twowaymirrors.com/tvmirror/)

TV 디스플레이에 알맞게 거울을 재단한 후, 거울을 TV 디스플레이에 접합합니다.

#### 2. 터치 패널 장착
터치 입력 지원을 위해, 적외선 터치 패널을 준비합니다.  
플러그 앤 플레이 방식의 터치 패널이 필요합니다.
터치 패널은 다음 링크에서 구매가 가능합니다.

* [하이드림엘씨디](http://itempage3.auction.co.kr/DetailView.aspx?ItemNo=A603955734&frm3=V2)
* [코리아정보통신](http://itempage3.auction.co.kr/DetailView.aspx?ItemNo=A514733995&frm3=V2)

#### 3. 미니PC 및 Raspberry PI 설치
적당한 크기와 성능의 미니PC와 라즈베리 파이를 준비한 후 TV에 연결합니다.  
이때 라즈베리 파이는 반드시 HDMI로 TV와 연결되도록 합니다.  
libcec가 지원하는 브랜드의 TV여야 합니다.

#### 4. Raspberry PI 센서 연결
라즈베리 파이에 인체감지 센서를 연결합니다.  
사람을 감지할 수 있도록 적절한 위치에 센서를 부착합니다.  
본 설명서에서 프로토타입에 사용한 제품은 다음과 같습니다.

* [PIR 인체감지 센서](http://www.artrobot.co.kr/front/php/product.php?product_no=757&main_cate_no=&display_group=)

### 소프트웨어
#### 1. Windows 설치
플랫폼 설치를 위해 Windows를 설치합니다.  
상단에서 준비한 터치 디스플레이와 호환될 수 있어야 합니다.

#### 2. 플랫폼 코어 설치
코어를 적절한 폴더에 복사 후, 실행합니다.  
실행 후에는 코어의 데이터 경로가 자동으로 생성됩니다.  
데이터 경로 및 구조에 관한 자세한 설명은 코어의 주요 문서를 참조하시기 바랍니다.

#### 3. 다양한 위젯 설치
설치를 원하는 위젯 파일을 플랫폼 경로에 복사하는 것만으로 위젯을 설치할 수 있습니다.  
설치된 위젯은 플랫폼 재시작시 자동으로 검색 및 사용할 수 있게됩니다.

## 문서
###주요 문서
* [코어 (Core)](https://github.com/1step6thswmaestro/12/blob/master/docs/Core.md)
* [캘린더 위젯 (Calendar Widget)](https://github.com/1step6thswmaestro/12/blob/master/docs/CalendarWidget.md)
* [시계 위젯 (Clock Widget)](https://github.com/1step6thswmaestro/12/blob/master/docs/ClockWidget.md)
* [갤러리 위젯 (Gallery Widget)](https://github.com/1step6thswmaestro/12/blob/master/docs/GalleryWidget.md)
* [날씨 위젯 (Weather Widget)](https://github.com/1step6thswmaestro/12/blob/master/docs/WeatherWidget.md)
* [음악 위젯 (Music Widget)](https://github.com/1step6thswmaestro/12/blob/master/docs/MusicWidget.md)
* [소식 위젯 (RSS Widget)](https://github.com/1step6thswmaestro/12/blob/master/docs/RSSWidget.md)
* [하드웨어 관련 (Hardwares)](https://github.com/1step6thswmaestro/12/blob/master/docs/Hardware.md)

###기타 문서
* [FlowingJS Document](https://github.com/1step6thswmaestro/12/tree/master/widgets/weather/libs)


## 라이센스
MIT Licnese
