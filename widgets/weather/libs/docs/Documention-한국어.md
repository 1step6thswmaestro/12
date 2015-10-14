# FlowingJS
FlowingJS는 자바스크립트 앱을 위한 데이터 흐름 제어기입니다.

FlowingJS는 데이터 흐름을 좀 더 쉽게 제어할 수 있습니다. 앱의 규모가 커질수록 복잡해지는 아키텍처에서 FlowingJS는 데이터가 흐르는 방향을 쉽게 설정할 수 있도록 도와줄 것입니다. 또한, 가시적으로 데이터의 흐름을 보여주기도 하여 여러분이 웹 앱의 아키텍처를 설계할 때 많은 도움이 될 것입니다.


## 영향을 받은 것들
저는 [Flux](https://github.com/facebook/flux)를 즐겨 사용합니다. 저는 웹 앱을 개발할 때 보통 Action, Dispatcher, Store, View로 나누어 아키텍처를 설계하고 모듈들을 개발했습니다. 하지만 Flux를 사용하면서 불편한 점이 많았습니다. 단방향이라는 심플한 데이터 플로우가 앱의 규모가 커질수록 복잡해졌고, Dispatch하는 과정에서도 많은 제약이 있었습니다. 그래서 좀 더 편리하게 데이터 흐름을 제어할 수 있는 방법이 없을까 고민한 끝에 FlowingJS를 개발하게 되었습니다.


## 설치
FlowingJS는 [npm 모듈](https://www.npmjs.com/package/flowing-js)로 설치가 가능합니다. 다음과 같이 npm 패키지를 이용해 설치합니다.
```shell
npm install --save flowing-js
```

그리고 FlowController는 ``flowing-js``패키지에서 다음과 같이 사용합니다.
```javascript
var FlowController = require('flowing0js').FlowController;
```

## 사용법
### 1. 모듈 분리하기
[Flux](https://github.com/facebook/flux)의 단방향 아키텍처를 이용합니다.

![img1](https://lh3.googleusercontent.com/fSq_Ml7fL8h0-gq_H0UmIMGJppv_iAdZw_3r4t1dt-NffEFh0NjGpUVN9ZRxG9bRGTgtLDUuKrmQWXd7z-PhN7kkfg63alroAeQTjpcai2hPUSC7vt-A7A_tIGYJ2QoBMMxVWqi6dKM7JEuMMGpfRKt-MmTzw2hCS-R4x2cCsc5ZVXVOsVHovrcuOyJYHgDybEshPqcEreyQMNOhhOJ5xVd16rRPPp58mHw65t4MoVgO41h27hyzXV3xSAxVFhD7xk2wcr-q1kRSwlrv4sabeGakjGCneT9o5yxc0oyWsIYqoxWVq1ByC5fOJ0_cRdgDO-LpPbFDMHuA708NgxD4R0LPj_lmsj0niXOXyRck_lzxbip_OxJptteMd9JgcDT4XmpRtSvYbuusEd54g6afRdGt7VGmDl_jFC-glpxB__F7pe2oJfGUf7b8CnY77Cbh4udwKiI9adkEBBZyvbiEO_R3nO-sRdzgKvQlQnmwDxhpoNT2AWOPiwgsSN__46lvZv2JFCLeAHrXPKHtpskGtyjVGhQR-zQnVnBpeaOT7WQ=w506-h580-no)

Dispatcher는 액션을 전달합니다. 전달된 액션은 FlowingJS에 의해 target으로 이동합니다. [Flux](https://github.com/facebook/flux)에서 데이터를 저장하는 곳은 Store이므로 액션의 target은 Store가 될 것입니다. 그리고 Store에서는 전달받은 액션을 검토하고 처리합니다. 이후에 FlowingJS는 해당 액션을 구독한 곳에 액션이 전달되어서 데이터 처리가 이루어졌다는 것을 알립니다.

말로 이렇게 설명하는 것보다 코드 몇 줄로 이해하는게 더 빠를겁니다. FlowingJS를 사용하기 위해 먼저 ```Flowing Controller```를 만듭니다.

**AppFlowController.js**
```javascript
var FlowController = require('flowing-js').FlowController;
var AppFlowController = new FlowController();

module.exports = AppFlowController.js;
```


### 2. 흐름 만들기
액션이 흐를 수 있는 흐름을 만들어 봅시다. **AppFlowController.js**에 다음과 같은 내용을 추가합니다.

**AppFlowController.js**
```javascript
var FlowController = require('flowing-js').FlowController;
var AppFlowController = new FlowController();

AppFlowController.addFlow('FLOW_ID_1');

module.exports = AppFlowController.js;
```
``'FLOW_ID_1'``은 흐름의 고유 ID입니다. 이 ID는 고유해야 합니다. [KeyMirror](https://github.com/STRML/keyMirror)와 같은 패키지를 이용해 상수를 만들어서 ID로 사용하시기 바랍니다.


### 3. 액션 발생시키기 & 액션 보내기
액션은 ``FlowController``의 ``dispatch``메서드를 이용합니다. 다음과 같이 액션을 발생시키는 모듈을 만듭니다.

**AppDispatcher.js**
```javascript
var AppFlowController = require('./AppFlowConroller');

var AppDispatcher = {
	setText: function(text) {
    	AppFlowController.dispatch(
        	'FLOW_ID_1',
            { text: text }
        );
    }
};

module.exports = AppDispatcher;
```

**AppView.js**
```javascript
var AppDispatcher = require('./AppDispatcher');

var SubmitButtonDOM;
var InputDOM;
var TextDOM;

var AppView = {
	initialize: function($) {
    	SubmitButtonDOM = $('#SubmitButton');
        InputDOM = $('#Input');
        TextDOM = $('#Text');
        
        SubmitButtonDOM.on('click', function() {
        	var text = InputDOM.val();
            AppDispatcher.setText(text);
        });
    }
};

module.exports = AppView;
```

### 4. 액션 받기
**AppStore.js**
```javascript
var AppFlowController = require('./AppFlowController');
var Promise = require('flowing-js').Promise;

var _text = "";

function setText(text) {
	_text = text;
}

var AppStore = {
	getText: function() {
    	return _text;
    },
    
    setText: AppFlowController.addTarget(
    	'FLOW_ID_1',
        function(payload) {
        	return new Promise(function(resolve, reject) {
            	setText(payload.text);
                resolve();
            });
        }
    )
};

module.exports = AppStore;
```

### 5. 액션 알리기

**AppView.js**
```javascript
var AppFlowController = require('./AppFlowController');
var AppDispatcher = require('./AppDispatcher');
var AppStore = require('./AppStore');

var SubmitButtonDOM;
var InputDOM;
var TextDOM;

var AppView = {
	initialize: function($) {
    	SubmitButtonDOM = $('#SubmitButton');
        InputDOM = $('#Input');
        TextDOM = $('#Text');
        
        SubmitButtonDOM.on('click', function() {
        	var text = InputDOM.val();
            AppDispatcher.setText(text);
        });
    },
    
    subscribeSetText: AppFlowController.addSubscribe(
    	'FLOW_ID_1',
        function() {
        	TextDOM.text(AppStore.getText());
            InputDOM.val("");
        }
    )
};

module.exports = AppView;
```
