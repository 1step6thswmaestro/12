# Core
* Team. JARVIS : **소현섭** (iodes, [iodesme@gmail.com](mailTo:iodesme@gmail.com), [Facebook](https://www.facebook.com/profile.php?id=100009172387549))
* 해당 문서는 [Lumino](https://github.com/1step6thswmaestro/12) 플랫폼의 [코어(Core)](https://github.com/1step6thswmaestro/12/tree/master/core) 부분에 대하여 기술합니다.

## 위젯 구성
코어에서는 다음의 형식으로 작성한 위젯 파일을 자동으로 불러옵니다.

### 패키지 규칙
모든 위젯 패키지는 다음의 규칙을 준수해야합니다.
* 파일 이름은 특수문자 및 숫자를 제외한 영문으로 작성합니다.
* 위젯의 섬네일은 위젯 구성 파일과 동일한 이름의 정사각형 PNG파일입니다.
* 모든 위젯은 \<WIDGET\>.INI 형식의 구성 파일과, \<WIDGET\>.PNG 형식의 섬네일을 포함해야 합니다.
* 만약 위의 규칙을 준수하지 않거나, 잘못된 구성 파일을 작성한 경우 해당 위젯은 로드되지 않습니다.

### 치환자 목록
위젯 구성 파일에서는 다음의 치환자를 사용할 수 있습니다.
* **\<%LOCAL%\>**
  * 현재 구성 파일이 존재하는 절대 경로입니다.

### 구성 파일 규격

    [General]
    ; 위젯의 제목을 입력합니다.
    ; 특수문자와 숫자를 제외한 모든 언어로 입력할 수 있습니다.
    Title=
    
    ; 위젯의 제작자 이름을 입력합니다.
    ; 특수문자와 숫자를 포함한 모든 문자를 입력할 수 있습니다.
    Author=
    
    ; 위젯의 설명을 입력합니다.
    ; 특수문자와 숫자를 포함한 모든 문자를 입력할 수 있습니다.
    Summary=
    
    [Assembly]
    ; 확장자를 포함한 위젯 파일의 이름을 입력합니다.
    ; 치환자를 사용하여 상대 경로로 입력하는것을 권장합니다.
    ; 만약 플랫폼에 포함된 기능을 사용하는 경우 「local」 로 입력합니다.
    ; Windows 환경에서 경로 문자열로 사용할 수 있는 모든 문자를 입력할 수 있습니다.
    File=
    
    ; 위젯의 엔트리 포인트 이름을 입력합니다.
    ; 만약 플랫폼에 포함된 기능을 사용하기 위해 「File」항목을 「local」로 입력한 경우,
    ; 하단의 기본 엔트리 포인트 목록을 참고하여 원하는 기본 기능에 접근할 수 있습니다.
    ; 특수문자와 숫자를 제외한 영문으로 입력할 수 있습니다.
    Entry=
    
    ; 위젯에 전달할 인자값을 입력합니다.
    ; 필요한 경우 치환자를 사용할 수 있습니다.
    ; 특수문자와 숫자를 포함한 모든 문자를 입력할 수 있습니다.
    ; 만약 전달이 필요한 인자값이 없는 경우 본 항목을 제거하십시오.
    Argument=
    
    [Appearance]
    ; 위젯의 가로 크기를 입력합니다.
    ; 단위는 위젯이 차지할 열의 개수입니다.
    ; 자연수로만 입력할 수 있습니다.
    Width=
    
    ; 위젯의 세로 크기를 입력합니다.
    ; 단위는 위젯이 차지할 행의 개수입니다.
    ; 자연수로만 입력할 수 있습니다.
    Height=
    
    ; 위젯이 전체 화면 모드를 사용할 수 있는지를 설정합니다.
    ; 전체 화면 모드를 포함한 경우 「True」, 그렇지 않은 경우 「False」입니다.
    Expandable=

### 구성 파일 예시
**네이티브 음악 위젯**

    [General]
    Title=음악
    Author=소현섭
    Summary=심플한 음악 위젯입니다.
    
    [Assembly]
    File=<%LOCAL%>\Music.dll
    Entry=Widget
    
    [Appearance]
    Width=5
    Height=5
    Expandable=True

**웹 엔진을 사용한 날씨 위젯**

    [General]
    Title=날씨
    Author=나석주
    Summary=웹 엔진을 활용한 날씨 위젯입니다.
    
    [Assembly]
    File=local
    Entry=WebView
    Argument=<%LOCAL%>\index.html
    
    [Appearance]
    Width=5
    Height=5
    Expandable=True

### 기본 엔트리 포인트 목록
위젯 구성 파일에서는 다음의 기본 엔트리 포인트를 사용할 수 있습니다.
* **WebView**
  * 위젯을 표시하기 위해 웹 엔진을 사용합니다.
  * 표시할 웹 페이지의 주소를 인자값으로 받습니다.
  * 인자값에 치환자를 사용하여 로컬 파일을 표시할 수 있습니다.

## 플랫폼 구성
플랫폼에서 사용하는 경로 및 구성 파일의 목록입니다.

### 위젯
* **%APPDATA%\Lumino\Widgets**
  * 본 경로에 있는 위젯을 자동으로 불러옵니다.
  * 위젯은 본 경로의 하위에 폴더 단위로 존재합니다.

### 설정
* **%APPDATA%\Lumino\Config.cfg**
  * 본 파일에 플랫폼의 설정이 기록됩니다.
  * 임의로 조작하는 경우 오작동의 가능성이 있습니다.

## 사용된 라이브러리
[CefSharp](https://github.com/cefsharp/CefSharp)
