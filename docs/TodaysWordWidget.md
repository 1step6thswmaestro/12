# TodaysWord Widget
* Team. JARVIS : **나석주** (seokju-na, [seokmaTD@gmail.com](mailTo:seokmaTD@gmail.com), [Facebook](https://www.facebook.com/seokma))
* 해당 문서는 [Lumino](https://github.com/1step6thswmaestro/12) 플랫폼을 위한 [명언 위젯(TodaysWord Widget)](https://github.com/1step6thswmaestro/12/tree/master/widgets/todays-word)에 대하여 기술합니다.


## 플랫폼에 설치하기
본 위젯을 표준적인 방법으로 플랫폼에 설치합니다.  
위젯의 자세한 설치 방법은 코어의 설명 문서를 참조하시기 바랍니다.

본 위젯의 엔트리 포인트는 `/build/index.html`입니다.


## 빌드 및 실행하기
node 패키지를 설치합니다.

```shell
$ npm install
```

걸프(gulp)을 실행하여 빌드 및 실행합니다.

```shell
$ gulp
```

http://localhost:3000에 접속하면 소스(./src/)에 변경 사항이 있을 시 실시간으로 반영됩니다.

빌드된 파일들은 build 폴더에 위치합니다.
