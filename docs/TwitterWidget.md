# Twitter Widget
* Team. JARVIS : **박인범** (nulledge, [nulledge@naver.com](mailTo:nulledge@naver.com), [Facebook](https://www.facebook.com/inbum.park.58))
* 해당 문서는 [Lumino](https://github.com/1step6thswmaestro/12) 플랫폼을 위한 [트위터 위젯(Twitter Widget)](https://github.com/1step6thswmaestro/12/tree/master/widgets/TwitterWidget)에 대하여 기술합니다.

## 사용법
해당 폴더에 'key.json' 파일을 생성합니다. key.json에는 ConsumerKey, ConsumerSecret, AccessToken, AccessTokenSecret 항목이 존재합니다.  [트위터 앱 관리 페이지](https://apps.twitter.com)에서 새로운 앱을 생성한 후 해당 키를 key.json 파일에 저장합니다. 위젯 실행 시 등록된 사용자의 타임라인을 스트리밍해서 보여줍니다.

## key.json
key.json 파일은 트위터에서 정보를 갖기 위한 사용자 인증 정보를 저장합니다. 아래 형식을 갖습니다.
```json
{
    'ConsumerKey' : 'Here is Consumer Key',
    'ConsumerSecrey' : 'Here is Consumer Secret',
    'AccessToken' : 'Here is Access Token',
    'AccessTokenSecret' : 'Here is Access Token Secret'
}
```

## 사용 API
* [LINQ to Twitter](https://linqtotwitter.codeplex.com/)
