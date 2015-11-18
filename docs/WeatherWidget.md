# Weather Widget
* Team. JARVIS : **나석주** (seokju-na, [seokmaTD@gmail.com](mailTo:seokmaTD@gmail.com), [Facebook](https://www.facebook.com/seokma))
* 해당 문서는 [Lumino](https://github.com/1step6thswmaestro/12) 플랫폼을 위한 [날씨 위젯(Weather Widget)](https://github.com/1step6thswmaestro/12/tree/master/widgets/weather)에 대하여 기술합니다.




## 디렉토리 구성

```
.
├── /build/                     # 컴파일 아웃풋(Compile Output)
├── /libs/                      # 관련 라이브러리 파일
├── /src/                       # 소스 코드
│   ├── /components/            # 컴포넌트(model + view)
│   ├── /constants/             # 상수
│   ├── /controller/            # FlowController
│   ├── /dispatcher/            # FlowController - Dispathcer
│   ├── /stores/                # FlowController - Store
│   ├── /utils/                 # Util들
│   ├── /index.html             # index.html
│   ├── /main.js                # main.js
│   └── /main.less              # main.less(스타일시트)
│
│── .gitignore                  # .gitignore
│── app.js                      # 테스트 서버 사이드 Startup 스크립트
│── gulpfile.js                 # Gulp 빌드 구성
│── trash.js                    # trash codes
│── package.json                # 패키지 구성
└── README.md                   # README.md
```

## FlowingJS - 관련 라이브러리
[FlowingJS](https://github.com/seokju-na/FlowingJS)

웹 앱의 아키텍처를 쉽게 설계하기 위한 JS 유틸리티. Data Flow Controller.
위젯 개발 과정 중 [Flux](https://facebook.github.io/flux/)을 사용하면서 따른 불편한 점들을 해결하기 위해 만들었습니다.

```shell
$ npm install flowing-js
$ npm install --save flowing-js
```

npm 패키지로 설치가 가능합니다



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
