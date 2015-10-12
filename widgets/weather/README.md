# Weather Widget
소프트웨어 마에스트로 1단계 2차 프로젝트

Weather Widget 날씨 위젯

Team. JARVIS



## 디렉토리 구성

```
.
├── /build/                     # 컴파일 아웃풋(Compile Output)
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
│── app.js                      # 서버 사이드 Startup 스크립트
│── gulpfile.js                 # Gulp 빌드 구성
│── trash.js                    # trash codes
│── package.json                # 패키지 구성
└── README.md                   # README.md
```

## FlowingJS
[FlowingJS](https://github.com/seokju-na/FlowingJS)

쉬운 웹 앱 아키텍처 설계를 위한 JS 유틸리티. Data Flow Controller

```shell
$ npm install flowing-js
$ npm install --save flowing-js
```

npm 패키지로 설치가 가능합니다



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