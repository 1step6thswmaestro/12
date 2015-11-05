/**
 * 이 클래스는 언어 선택을 위한 클래스입니다.
 * 이 클래스는 컴포넌트가 Context를 가져올 때 호출됩니다.
 * 현재 선택된 언어를 가져오고 싶은 경우 getCurrentLanguage() 메소드 사용하여 수행한다.
 *
 * @version 151028
 * @author 나석주
 */

var LanguageSelector = {
    getCurrentLanguage: function() {
        return 'KR';
    }
};

module.exports = LanguageSelector;