# JARVIS - Weather Widget
소프트웨어 마에스트로 1단계 2차 프로젝트 

Team. JARVIS



## 디렉토리 구성

```
.
├── /build/                     # 컴파일 아웃풋(Compile Output)
├── /src/                       # 소스 코드
│   ├── /actions/               # Flux - 액션 생성기(action creator)
│   ├── /apis/                  # WebAPI 유틸리티
│   ├── /components/            # 컴포넌트(model + view)
│   ├── /constants/             # 상수
│   ├── /dispatcher/            # Flux - Dispathcer
│   ├── /stores/                # Flux - Store
│   ├── /utils/                 # Util들
│   ├── /index.html             # index.html
│   ├── /main.js                # main.js
│   └── /main.less              # main.less(스타일시트)
│
│── .gitignore                  # .gitignore
│── app.js                      # 서버 사이드 Startup 스크립트
│── gulpfile.js                 # Gulp 빌드 구성
│── package.json                # 패키지 구성
└── README.md                   # README.md
```




## 빌드 및 실행하기
먼저 git clone을 다운받습니다.

```shell
$ git clone https://github.com/soma-JARVIS/weather.git
```

그 다음 node 패키지를 설치합니다.

```shell
$ npm install
```

걸프(gulp)을 실행하여 빌드 및 실행합니다.

```shell
$ gulp
```

http://localhost:3000에 접속하면 소스(./src/)에 변경 사항이 있을 시 실시간으로 반영됩니다.

빌드된 파일들은 build 폴더에 위치합니다.