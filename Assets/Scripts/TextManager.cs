using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public PlayerPrefsManager playerPrefsManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetLocalizeText(string jaText)
    {
        string langCode = playerPrefsManager.GetLanguage();

        if(jaText == "データ引き継ぎ")
        {
            switch (langCode)
            {
                case "ja":
                    return "データ引き継ぎ";
                case "en":
                    return "data transfer";
                case "zh-cn":
                    return "数据传输";
                case "zh-tw":
                    return "資料傳輸";
                case "ko":
                    return "데이터 전송";
                case "es":
                    return "transferencia de datos";
                case "fr":
                    return "transfert de données";
                case "de":
                    return "Datenübertragung";
                case "it":
                    return "trasferimento dati";
                case "pt":
                    return "transferência de dados";
                case "ru":
                    return "передача данных";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "引き継ぎコード")
        {
            switch (langCode)
            {
                case "ja":
                    return "引き継ぎコード";
                case "en":
                    return "transfer code";
                case "zh-cn":
                    return "传输代码";
                case "zh-tw":
                    return "傳輸代碼";
                case "ko":
                    return "전송 코드";
                case "es":
                    return "código de transferencia";
                case "fr":
                    return "code de transfert";
                case "de":
                    return "Übertragungscode";
                case "it":
                    return "codice di trasferimento";
                case "pt":
                    return "código de transferência";
                case "ru":
                    return "код передачи";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "データ引き継ぎ失敗")
        {
            switch (langCode)
            {
                case "ja":
                    return "データ引き継ぎ失敗";
                case "en":
                    return "data transfer failure";
                case "zh-cn":
                    return "数据传输失败";
                case "zh-tw":
                    return "資料傳輸失敗";
                case "ko":
                    return "데이터 전송 실패";
                case "es":
                    return "falla en la transferencia de datos";
                case "fr":
                    return "échec du transfert de données";
                case "de":
                    return "Datenübertragungsfehler";
                case "it":
                    return "fallimento del trasferimento dati";
                case "pt":
                    return "falha na transferência de dados";
                case "ru":
                    return "сбой передачи данных";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "引き継ぎコードを確認して、再度お試しください。")
        {
            switch (langCode)
            {
                case "ja":
                    return "引き継ぎコードを確認して、再度お試しください。";
                case "en":
                    return "Please verify the transfer code and try again.";
                case "zh-cn":
                    return "请验证传输代码并重试。";
                case "zh-tw":
                    return "請驗證傳輸代碼並重試。";
                case "ko":
                    return "전송 코드를 확인하고 다시 시도하세요.";
                case "es":
                    return "Verifique el código de transferencia y vuelva a intentarlo.";
                case "fr":
                    return "Veuillez vérifier le code de transfert et réessayer.";
                case "de":
                    return "Überprüfen Sie den Übertragungscode und versuchen Sie es erneut.";
                case "it":
                    return "Verifica il codice di trasferimento e riprova.";
                case "pt":
                    return "Verifique o código de transferência e tente novamente.";
                case "ru":
                    return "Проверьте код передачи и повторите попытку.";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "引き継ぎコードを入力して、OKを押してください。")
        {
            switch (langCode)
            {
                case "ja":
                    return "引き継ぎコードを入力して、OKを押してください。";
                case "en":
                    return "Please enter the transfer code and press OK.";
                case "zh-cn":
                    return "请输入传输代码，然后按OK键。";
                case "zh-tw":
                    return "請輸入傳輸代碼，然後按OK鍵。";
                case "ko":
                    return "전송 코드를 입력하고 OK를 누르세요.";
                case "es":
                    return "Por favor, introduzca el código de transferencia y presione OK.";
                case "fr":
                    return "Veuillez entrer le code de transfert et appuyer sur OK.";
                case "de":
                    return "Bitte geben Sie den Übertragungscode ein und drücken Sie OK.";
                case "it":
                    return "Inserisci il codice di trasferimento e premi OK.";
                case "pt":
                    return "Por favor, insira o código de transferência e pressione OK.";
                case "ru":
                    return "Введите код передачи и нажмите OK.";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "コピーライト等")
        {
            switch (langCode)
            {
                case "ja":
                    return "Copyright";
                case "en":
                    return "Copyright";
                case "zh-cn":
                    return "版权";
                case "zh-tw":
                    return "版權";
                case "ko":
                    return "저작권";
                case "es":
                    return "Derechos de autor";
                case "fr":
                    return "Droit d'auteur";
                case "de":
                    return "Urheberrecht";
                case "it":
                    return "Copyright";
                case "pt":
                    return "Direitos autorais";
                case "ru":
                    return "Авторское право";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "プライバシーポリシー")
        {
            switch (langCode)
            {
                case "ja":
                    return "プライバシーポリシー";
                case "en":
                    return "Privacy Policy";
                case "zh-cn":
                    return "隐私政策";
                case "zh-tw":
                    return "隱私政策";
                case "ko":
                    return "개인 정보 보호 정책";
                case "es":
                    return "Política de privacidad";
                case "fr":
                    return "Politique de confidentialité";
                case "de":
                    return "Datenschutzrichtlinie";
                case "it":
                    return "Informativa sulla privacy";
                case "pt":
                    return "Política de Privacidade";
                case "ru":
                    return "Политика конфиденциальности";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "プライバシーポリシーを確認して、OKを押してください。")
        {
            switch (langCode)
            {
                case "ja":
                    return "プライバシーポリシーを確認して、OKを押してください。";
                case "en":
                    return "Please review the privacy policy and press OK.";
                case "zh-cn":
                    return "请查看隐私政策并按OK键。";
                case "zh-tw":
                    return "請查看隱私政策並按OK鍵。";
                case "ko":
                    return "개인 정보 보호 정책을 검토하고 OK를 누르십시오.";
                case "es":
                    return "Revise la política de privacidad y presione OK.";
                case "fr":
                    return "Veuillez consulter la politique de confidentialité et appuyer sur OK.";
                case "de":
                    return "Bitte überprüfen Sie die Datenschutzrichtlinie und drücken Sie OK.";
                case "it":
                    return "Si prega di esaminare l'informativa sulla privacy e premere OK.";
                case "pt":
                    return "Por favor, reveja a política de privacidade e pressione OK.";
                case "ru":
                    return "Пожалуйста, ознакомьтесь с политикой конфиденциальности и нажмите OK.";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "プライバシーポリシーをWebサイトで確認する")
        {
            switch (langCode)
            {
                case "ja":
                    return "プライバシーポリシーをWebサイトで確認する";
                case "en":
                    return "View Privacy Policy on the website";
                case "zh-cn":
                    return "在网站上查看隐私政策";
                case "zh-tw":
                    return "在網站上查看隱私政策";
                case "ko":
                    return "웹 사이트에서 개인 정보 보호 정책 확인";
                case "es":
                    return "Ver la política de privacidad en el sitio web";
                case "fr":
                    return "Consulter la politique de confidentialité sur le site web";
                case "de":
                    return "Datenschutzrichtlinie auf der Website anzeigen";
                case "it":
                    return "Visualizza l'informativa sulla privacy sul sito web";
                case "pt":
                    return "Consultar a política de privacidade no site";
                case "ru":
                    return "Просмотреть политику конфиденциальности на веб-сайте";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "データ引き継ぎ完了")
        {
            switch (langCode)
            {
                case "ja":
                    return "データ引き継ぎ完了";
                case "en":
                    return "Data transfer completed";
                case "zh-cn":
                    return "数据传输完成";
                case "zh-tw":
                    return "資料傳輸完成";
                case "ko":
                    return "데이터 전송 완료";
                case "es":
                    return "Transferencia de datos completada";
                case "fr":
                    return "Transfert de données terminé";
                case "de":
                    return "Datenübertragung abgeschlossen";
                case "it":
                    return "Trasferimento dati completato";
                case "pt":
                    return "Transferência de dados concluída";
                case "ru":
                    return "Передача данных завершена";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "全てのデータが引き継がれているわけではございません。")
        {
            switch (langCode)
            {
                case "ja":
                    return "全てのデータが引き継がれているわけではございません。";
                case "en":
                    return "Not all data has been transferred.";
                case "zh-cn":
                    return "并非所有数据都已传输。";
                case "zh-tw":
                    return "並非所有資料都已傳輸。";
                case "ko":
                    return "모든 데이터가 전송되지 않았습니다.";
                case "es":
                    return "No se ha transferido toda la información.";
                case "fr":
                    return "Toutes les données n'ont pas été transférées.";
                case "de":
                    return "Nicht alle Daten wurden übertragen.";
                case "it":
                    return "Non tutti i dati sono stati trasferiti.";
                case "pt":
                    return " Nem todos os dados foram transferidos.";
                case "ru":
                    return "Не все данные были переданы.";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "攻撃力")
        {
            switch (langCode)
            {
                case "ja":
                    return "攻撃力";
                case "en":
                    return "Attack Power";
                case "zh-cn":
                    return "攻击力";
                case "zh-tw":
                    return "攻擊力";
                case "ko":
                    return "공격력";
                case "es":
                    return "Poder de ataque";
                case "fr":
                    return "Puissance d'attaque";
                case "de":
                    return "Angriffskraft";
                case "it":
                    return "Potenza d'attacco";
                case "pt":
                    return "Poder de Ataque";
                case "ru":
                    return "Сила атаки";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "回復力")
        {
            switch (langCode)
            {
                case "ja":
                    return "回復力";
                case "en":
                    return "Healing Power";
                case "zh-cn":
                    return "恢复力";
                case "zh-tw":
                    return "恢復力";
                case "ko":
                    return "회복력";
                case "es":
                    return "Poder de curación";
                case "fr":
                    return "Pouvoir de guérison";
                case "de":
                    return "Heilkraft";
                case "it":
                    return "Potere di guarigione";
                case "pt":
                    return "Poder de Cura";
                case "ru":
                    return "Сила исцеления";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "火山")
        {
            switch (langCode)
            {
                case "ja":
                    return "火山";
                case "en":
                    return "volcano";
                case "zh-cn":
                    return "火山";
                case "zh-tw":
                    return "火山";
                case "ko":
                    return "화산";
                case "es":
                    return "volcán";
                case "fr":
                    return "volcan";
                case "de":
                    return "Vulkan";
                case "it":
                    return "vulcano";
                case "pt":
                    return "vulcão";
                case "ru":
                    return "вулкан";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "クリア済み")
        {
            switch (langCode)
            {
                case "ja":
                    return "クリア済み";
                case "en":
                    return "Cleared";
                case "zh-cn":
                    return "已清除";
                case "zh-tw":
                    return "已清除";
                case "ko":
                    return "클리어됨";
                case "es":
                    return "Completado";
                case "fr":
                    return "Terminé";
                case "de":
                    return "Abgeschlossen";
                case "it":
                    return "Completato";
                case "pt":
                    return "Concluído";
                case "ru":
                    return "Очищено";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "挑戦レベル")
        {
            switch (langCode)
            {
                case "ja":
                    return "挑戦レベル";
                case "en":
                    return "Challenge Level";
                case "zh-cn":
                    return "挑战级别";
                case "zh-tw":
                    return "挑戰級別";
                case "ko":
                    return "도전 레벨";
                case "es":
                    return "Nivel de desafío";
                case "fr":
                    return "Niveau de défi";
                case "de":
                    return "Herausforderungsstufe";
                case "it":
                    return "Livello di sfida";
                case "pt":
                    return "Nível de desafio";
                case "ru":
                    return "Уровень сложности";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "船")
        {
            switch (langCode)
            {
                case "ja":
                    return "船";
                case "en":
                    return "ship";
                case "zh-cn":
                    return "船";
                case "zh-tw":
                    return "船";
                case "ko":
                    return "배";
                case "es":
                    return "barco";
                case "fr":
                    return "navire";
                case "de":
                    return "Schiff";
                case "it":
                    return "nave";
                case "pt":
                    return "navio";
                case "ru":
                    return "корабль";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "森林")
        {
            switch (langCode)
            {
                case "ja":
                    return "森林";
                case "en":
                    return "forest";
                case "zh-cn":
                    return "森林";
                case "zh-tw":
                    return "森林";
                case "ko":
                    return "숲";
                case "es":
                    return "bosque";
                case "fr":
                    return "forêt";
                case "de":
                    return "Wald";
                case "it":
                    return "foresta";
                case "pt":
                    return "floresta";
                case "ru":
                    return "лес";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "ボス")
        {
            switch (langCode)
            {
                case "ja":
                    return "ボス";
                case "en":
                    return "boss";
                case "zh-cn":
                    return "老板";
                case "zh-tw":
                    return "老闆";
                case "ko":
                    return "보스";
                case "es":
                    return "jefe";
                case "fr":
                    return "patron";
                case "de":
                    return "Chef";
                case "it":
                    return "capo";
                case "pt":
                    return "chefe";
                case "ru":
                    return "босс";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "倍率")
        {
            switch (langCode)
            {
                case "ja":
                    return "倍率";
                case "en":
                    return "magnification";
                case "zh-cn":
                    return "放大率";
                case "zh-tw":
                    return "放大率";
                case "ko":
                    return "배율";
                case "es":
                    return "amplificación";
                case "fr":
                    return "grossissement";
                case "de":
                    return "Vergrößerung";
                case "it":
                    return "ingrandimento";
                case "pt":
                    return "ampliação";
                case "ru":
                    return "увеличение";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "BGM音量")
        {
            switch (langCode)
            {
                case "ja":
                    return "BGM音量";
                case "en":
                    return "BGM volume";
                case "zh-cn":
                    return "背景音乐音量";
                case "zh-tw":
                    return "背景音樂音量";
                case "ko":
                    return "배경 음악 볼륨";
                case "es":
                    return "Volumen de BGM";
                case "fr":
                    return "Volume de la musique de fond";
                case "de":
                    return "Hintergrundmusik Lautstärke";
                case "it":
                    return "Volume della musica di sottofondo";
                case "pt":
                    return "Volume da música de fundo";
                case "ru":
                    return "Громкость фоновой музыки";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "SE音量")
        {
            switch (langCode)
            {
                case "ja":
                    return "SE音量";
                case "en":
                    return "SE volume";
                case "zh-cn":
                    return "SE音量";
                case "zh-tw":
                    return "SE音量";
                case "ko":
                    return "효과음 볼륨";
                case "es":
                    return "Volumen de efectos de sonido";
                case "fr":
                    return "Volume des effets sonores";
                case "de":
                    return "Effektlautstärke";
                case "it":
                    return "Volume effetti sonori";
                case "pt":
                    return "Volume de efeitos sonoros";
                case "ru":
                    return "Громкость звуковых эффектов";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "言語")
        {
            switch (langCode)
            {
                case "ja":
                    return "言語";
                case "en":
                    return "language";
                case "zh-cn":
                    return "语言";
                case "zh-tw":
                    return "語言";
                case "ko":
                    return "언어";
                case "es":
                    return "idioma";
                case "fr":
                    return "langue";
                case "de":
                    return "Sprache";
                case "it":
                    return "lingua";
                case "pt":
                    return "idioma";
                case "ru":
                    return "язык";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "OKを押すと言語が切り替わります。一度ゲームのトップに戻ります。")
        {
            switch (langCode)
            {
                case "ja":
                    return "OKを押すと言語が切り替わります。一度ゲームのトップに戻ります。";
                case "en":
                    return "Press OK to switch the language. You will return to the game's top.";
                case "zh-cn":
                    return "按下 OK 切换语言。您将返回游戏的顶部。";
                case "zh-tw":
                    return "按下 OK 切換語言。您將返回遊戲的頂部。";
                case "ko":
                    return "OK를 누르면 언어가 변경됩니다. 게임의 맨 위로 돌아갑니다.";
                case "es":
                    return "Presiona OK para cambiar el idioma. Volverás a la parte superior del juego.";
                case "fr":
                    return "Appuyez sur OK pour changer la langue. Vous retournerez en haut du jeu.";
                case "de":
                    return "Drücken Sie OK, um die Sprache zu wechseln. Sie kehren zum Anfang des Spiels zurück.";
                case "it":
                    return "Premi OK per cambiare lingua. Tornerai all'inizio del gioco.";
                case "pt":
                    return "Pressione OK para alterar o idioma. Você retornará ao topo do jogo.";
                case "ru":
                    return "Нажмите OK, чтобы изменить язык. Вы вернетесь в начало игры.";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "コード生成")
        {
            switch (langCode)
            {
                case "ja":
                    return "コード生成";
                case "en":
                    return "Code generation";
                case "zh-cn":
                    return "代码生成";
                case "zh-tw":
                    return "程式碼生成";
                case "ko":
                    return "코드 생성";
                case "es":
                    return "Generación de código";
                case "fr":
                    return "Génération de code";
                case "de":
                    return "Codegenerierung";
                case "it":
                    return "Generazione del codice";
                case "pt":
                    return "Geração de código";
                case "ru":
                    return "Генерация кода";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "引き継ぎ方法の説明")
        {
            switch (langCode)
            {
                case "ja":
                    return "別の端末にデータを引き継ぐにはこちらのコードをお使い下さい。※プレイヤーデータの一部が引き継ぎ対象になります。全てのデータが引き継がれるわけではございません。";
                case "en":
                    return "To transfer data to another device, please use this code. ※ Some player data will be transferred, not all data will be transferred.";
                case "zh-cn":
                    return "要将数据转移到另一台设备，请使用此代码。※将传输部分玩家数据，而不是所有数据。";
                case "zh-tw":
                    return "要將數據轉移到另一台設備，請使用此代碼。※將傳輸部分玩家數據，而不是所有數據。";
                case "ko":
                    return "데이터를 다른 기기로 이전하려면 이 코드를 사용하십시오. ※ 일부 플레이어 데이터가 이전되며 모든 데이터가 이전되지는 않습니다.";
                case "es":
                    return "Para transferir datos a otro dispositivo, utilice este código. ※ Se transferirán algunos datos del jugador, no todos los datos.";
                case "fr":
                    return "Pour transférer des données vers un autre appareil, veuillez utiliser ce code. ※ Certaines données du joueur seront transférées, pas toutes les données.";
                case "de":
                    return "Um Daten auf ein anderes Gerät zu übertragen, verwenden Sie diesen Code. ※ Einige Spielerdaten werden übertragen, nicht alle Daten.";
                case "it":
                    return "Per trasferire i dati su un altro dispositivo, utilizzare questo codice. ※ Alcuni dati del giocatore verranno trasferiti, non tutti i dati.";
                case "pt":
                    return "Para transferir dados para outro dispositivo, utilize este código. ※ Alguns dados do jogador serão transferidos, não todos os dados.";
                case "ru":
                    return "Чтобы передать данные на другое устройство, используйте этот код. ※ Будут переданы некоторые данные игрока, не все данные.";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "プレイヤー情報")
        {
            switch (langCode)
            {
                case "ja": // 日本語
                    return "プレイヤー情報";
                case "en": // 英語
                    return "Player Information";
                case "zh-cn": // 簡体字
                    return "玩家信息";
                case "zh-tw": // 繁体字
                    return "玩家資訊";
                case "ko": // 韓国語
                    return "플레이어 정보";
                case "es": // スペイン語
                    return "Información del jugador";
                case "fr": // フランス語
                    return "Informations du joueur";
                case "de": // ドイツ語
                    return "Spielerinformation";
                case "it": // イタリア語
                    return "Informazioni del giocatore";
                case "pt": // ポルトガル語
                    return "Informações do jogador";
                case "ru": // ロシア語
                    return "Информация о игроке";
                default:
                    return "未対応の言語";
            }
        }
        if (jaText == "特殊効果")
        {
            switch (langCode)
            {
                case "ja": // 日本語
                    return "特殊効果";
                case "en": // 英語
                    return "Special Effect";
                case "zh-cn": // 簡体字
                    return "特殊效果";
                case "zh-tw": // 繁体字
                    return "特殊效果";
                case "ko": // 韓国語
                    return "특수 효과";
                case "es": // スペイン語
                    return "Efecto Especial";
                case "fr": // フランス語
                    return "Effet Spécial";
                case "de": // ドイツ語
                    return "Spezialeffekt";
                case "it": // イタリア語
                    return "Effetto Speciale";
                case "pt": // ポルトガル語
                    return "Efeito Especial";
                case "ru": // ロシア語
                    return "Специальный эффект";
                default:
                    return "未対応の言語";
            }
        }
        if (jaText == "パラメータ異常・状態異常")
        {
            switch (langCode)
            {
                case "ja": // 日本語
                    return "パラメータ異常・状態異常";
                case "en": // 英語
                    return "Parameter Abnormality / State Abnormality";
                case "zh-cn": // 簡体字
                    return "参数异常 / 状态异常";
                case "zh-tw": // 繁体字
                    return "參數異常 / 狀態異常";
                case "ko": // 韓国語
                    return "매개 변수 이상 / 상태 이상";
                case "es": // スペイン語
                    return "Anomalía de Parámetros / Anomalía de Estado";
                case "fr": // フランス語
                    return "Anomalie des Paramètres / Anomalie de l'État";
                case "de": // ドイツ語
                    return "Parameteranomalie / Zustandsanomalie";
                case "it": // イタリア語
                    return "Anomalia dei Parametri / Anomalia di Stato";
                case "pt": // ポルトガル語
                    return "Anomalia dos Parâmetros / Anomalia do Estado";
                case "ru": // ロシア語
                    return "Аномалия параметров / Аномалия состояния";
                default:
                    return "未対応の言語";
            }
        }
        if (jaText == "装備するものを2つ選んでください")
        {
            switch (langCode)
            {
                case "ja": // 日本語
                    return "装備するものを2つ選んでください";
                case "en": // 英語
                    return "Please choose two items to equip";
                case "zh-cn": // 簡体字
                    return "请选择两个物品装备";
                case "zh-tw": // 繁体字
                    return "請選擇兩個物品裝備";
                case "ko": // 韓国語
                    return "두 가지 아이템을 선택하여 장착하세요";
                case "es": // スペイン語
                    return "Por favor, elija dos objetos para equipar";
                case "fr": // フランス語
                    return "Veuillez choisir deux objets à équiper";
                case "de": // ドイツ語
                    return "Bitte wählen Sie zwei Gegenstände zum Ausrüsten";
                case "it": // イタリア語
                    return "Per favore, scegli due oggetti da equipaggiare";
                case "pt": // ポルトガル語
                    return "Por favor, escolha dois itens para equipar";
                case "ru": // ロシア語
                    return "Пожалуйста, выберите два предмета для экипировки";
                default:
                    return "未対応の言語";
            }
        }
        if (jaText == "戦利品")
        {
            switch (langCode)
            {
                case "ja": // 日本語
                    return "戦利品";
                case "en": // 英語
                    return "Loot";
                case "zh-cn": // 簡体字
                    return "战利品";
                case "zh-tw": // 繁体字
                    return "戰利品";
                case "ko": // 韓国語
                    return "전리품";
                case "es": // スペイン語
                    return "Botín";
                case "fr": // フランス語
                    return "Butin";
                case "de": // ドイツ語
                    return "Beute";
                case "it": // イタリア語
                    return "Bottino";
                case "pt": // ポルトガル語
                    return "Saque";
                case "ru": // ロシア語
                    return "Добыча";
                default:
                    return "未対応の言語";
            }
        }
        if (jaText == "動画広告説明")
        {
            switch (langCode)
            {
                case "ja": // 日本語
                    return "動画広告を見ることで1時間の間報酬が1つ増えます\r\n（次の報酬から適用されます）";
                case "en": // 英語
                    return "Watching a video ad will increase your reward count by 1 for the next hour (applies to the next reward).";
                case "zh-cn": // 簡体字
                    return "观看视频广告将使您的奖励计数在接下来的一个小时内增加1个（适用于下一个奖励）。";
                case "zh-tw": // 繁体字
                    return "觀看影片廣告將使您的獎勵計數在接下來的一小時內增加1個（適用於下一個獎勵）。";
                case "ko": // 韓国語
                    return "비디오 광고를 시청하면 다음 1시간 동안 보상 횟수가 1회 증가합니다 (다음 보상에 적용됩니다).";
                case "es": // スペイン語
                    return "Ver un anuncio de video aumentará tu conteo de recompensas en 1 durante la próxima hora (se aplica a la próxima recompensa).";
                case "fr": // フランス語
                    return "Regarder une publicité vidéo augmentera votre nombre de récompenses de 1 pour la prochaine heure (valable pour la prochaine récompense).";
                case "de": // ドイツ語
                    return "Das Ansehen eines Videowerbespots erhöht Ihre Belohnungszählung für die nächsten 60 Minuten um 1 (gilt für die nächste Belohnung).";
                case "it": // イタリア語
                    return "Guardare un annuncio video aumenterà il conteggio delle tue ricompense di 1 per la prossima ora (si applica alla prossima ricompensa).";
                case "pt": // ポルトガル語
                    return "Assistir a um anúncio de vídeo aumentará sua contagem de recompensas em 1 pela próxima hora (aplica-se à próxima recompensa).";
                case "ru": // ロシア語
                    return "Просмотр видеорекламы увеличит количество ваших наград на 1 в течение следующего часа (применяется к следующей награде).";
                default:
                    return "未対応の言語";
            }
        }
        if (jaText == "広告を見る")
        {
            switch (langCode)
            {
                case "ja": // 日本語
                    return "広告を見る";
                case "en": // 英語
                    return "Watch Ad";
                case "zh-cn": // 簡体字
                    return "观看广告";
                case "zh-tw": // 繁体字
                    return "觀看廣告";
                case "ko": // 韓国語
                    return "광고 보기";
                case "es": // スペイン語
                    return "Ver anuncio";
                case "fr": // フランス語
                    return "Regarder la publicité";
                case "de": // ドイツ語
                    return "Werbung ansehen";
                case "it": // イタリア語
                    return "Guarda l'annuncio";
                case "pt": // ポルトガル語
                    return "Ver anúncio";
                case "ru": // ロシア語
                    return "Смотреть рекламу";
                default:
                    return "未対応の言語";
            }
        }
        if (jaText == "広告失敗")
        {
            switch (langCode)
            {
                case "ja": // 日本語
                    return "広告の視聴に失敗しました。\r\n通信環境をご確認の上、時間をあけてお試しください。";
                case "en": // 英語
                    return "Failed to watch the ad. Please check your network connection and try again later.";
                case "zh-cn": // 簡体字
                    return "观看广告失败。请检查您的网络连接并稍后重试。";
                case "zh-tw": // 繁体字
                    return "觀看廣告失敗。請檢查您的網絡連接並稍後重試。";
                case "ko": // 韓国語
                    return "광고 시청에 실패했습니다. 네트워크 연결을 확인하고 나중에 다시 시도해주세요.";
                case "es": // スペイン語
                    return "Error al ver el anuncio. Por favor, compruebe su conexión de red e inténtelo de nuevo más tarde.";
                case "fr": // フランス語
                    return "Échec de la visualisation de la publicité. Veuillez vérifier votre connexion réseau et réessayer ultérieurement.";
                case "de": // ドイツ語
                    return "Fehler beim Ansehen der Werbung. Bitte überprüfen Sie Ihre Netzwerkverbindung und versuchen Sie es später erneut.";
                case "it": // イタリア語
                    return "Impossibile visualizzare l'annuncio. Controlla la tua connessione di rete e riprova più tardi.";
                case "pt": // ポルトガル語
                    return "Falha ao assistir ao anúncio. Por favor, verifique sua conexão de rede e tente novamente mais tarde.";
                case "ru": // ロシア語
                    return "Не удалось просмотреть рекламу. Проверьте свое сетевое подключение и попробуйте позже.";
                default:
                    return "未対応の言語";
            }
        }
        if (jaText == "広告成功")
        {
            switch (langCode)
            {
                case "ja": // 日本語
                    return "次回から報酬が1つ増えます。";
                case "en": // 英語
                    return "Your reward will increase by 1 from the next time.";
                case "zh-cn": // 簡体字
                    return "下次奖励将增加1个。";
                case "zh-tw": // 繁体字
                    return "下次獎勵將增加1個。";
                case "ko": // 韓国語
                    return "다음 번에 보상이 1개 더 증가합니다.";
                case "es": // スペイン語
                    return "Tu recompensa aumentará en 1 a partir de la próxima vez.";
                case "fr": // フランス語
                    return "Votre récompense augmentera de 1 à partir de la prochaine fois.";
                case "de": // ドイツ語
                    return "Ihre Belohnung wird ab dem nächsten Mal um 1 erhöht.";
                case "it": // イタリア語
                    return "La tua ricompensa aumenterà di 1 a partire dalla prossima volta.";
                case "pt": // ポルトガル語
                    return "Sua recompensa aumentará em 1 a partir da próxima vez.";
                case "ru": // ロシア語
                    return "Ваша награда увеличится на 1 с следующего раза.";
                default:
                    return "未対応の言語";
            }
        }
        if (jaText == "ランダムで火を水に変換する")
        {
            switch (langCode)
            {
                case "ja":
                    return "ランダムで火を水に変換する";
                case "en":
                    return "Convert fire to water";
                case "zh-cn":
                    return "将火转化为水";
                case "zh-tw":
                    return "將火轉化為水";
                case "ko":
                    return "불을 물로 변환하기";
                case "es":
                    return "Convertir el fuego en agua";
                case "fr":
                    return "Convertir le feu en eau";
                case "de":
                    return "Feuer in Wasser umwandeln";
                case "it":
                    return "Convertire il fuoco in acqua";
                case "pt":
                    return "Converter fogo em água";
                case "ru":
                    return "Преобразовать огонь в воду";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "ランダムで火を木に変換する")
        {
            switch (langCode)
            {
                case "ja":
                    return "ランダムで火を木に変換する";
                case "en":
                    return "Convert fire to wood";
                case "zh-cn":
                    return "将火转化为木";
                case "zh-tw":
                    return "將火轉化為木";
                case "ko":
                    return "불을 나무로 변환하기";
                case "es":
                    return "Convertir el fuego en madera";
                case "fr":
                    return "Convertir le feu en bois";
                case "de":
                    return "Feuer in Holz umwandeln";
                case "it":
                    return "Convertire il fuoco in legno";
                case "pt":
                    return "Converter fogo em madeira";
                case "ru":
                    return "Преобразовать огонь в дерево";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "ランダムで火を回復に変換する")
        {
            switch (langCode)
            {
                case "ja":
                    return "ランダムで火を回復に変換する";
                case "en":
                    return "Convert fire to healing";
                case "zh-cn":
                    return "将火转化为治疗";
                case "zh-tw":
                    return "將火轉化為治療";
                case "ko":
                    return "불을 회복으로 변환하기";
                case "es":
                    return "Convertir el fuego en curación";
                case "fr":
                    return "Convertir le feu en guérison";
                case "de":
                    return "Feuer in Heilung umwandeln";
                case "it":
                    return "Convertire il fuoco in cura";
                case "pt":
                    return "Converter fogo em cura";
                case "ru":
                    return "Преобразовать огонь в исцеление";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "ランダムで水を火に変換する")
        {
            switch (langCode)
            {
                case "ja":
                    return "ランダムで水を火に変換する";
                case "en":
                    return "Convert water to fire";
                case "zh-cn":
                    return "将水转化为火";
                case "zh-tw":
                    return "將水轉化為火";
                case "ko":
                    return "물을 불로 변환하기";
                case "es":
                    return "Convertir agua en fuego";
                case "fr":
                    return "Convertir l'eau en feu";
                case "de":
                    return "Wasser in Feuer umwandeln";
                case "it":
                    return "Convertire l'acqua in fuoco";
                case "pt":
                    return "Converter água em fogo";
                case "ru":
                    return "Преобразовать воду в огонь";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "ランダムで水を木に変換する")
        {
            switch (langCode)
            {
                case "ja":
                    return "ランダムで水を木に変換する";
                case "en":
                    return "Convert water to wood";
                case "zh-cn":
                    return "将水转化为木";
                case "zh-tw":
                    return "將水轉化為木";
                case "ko":
                    return "물을 나무로 변환하기";
                case "es":
                    return "Convertir agua en madera";
                case "fr":
                    return "Convertir l'eau en bois";
                case "de":
                    return "Wasser in Holz umwandeln";
                case "it":
                    return "Convertire l'acqua in legno";
                case "pt":
                    return "Converter água em madeira";
                case "ru":
                    return "Преобразовать воду в дерево";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "ランダムで水を回復に変換する")
        {
            switch (langCode)
            {
                case "ja":
                    return "ランダムで水を回復に変換する";
                case "en":
                    return "Convert water to healing";
                case "zh-cn":
                    return "将水转化为治疗";
                case "zh-tw":
                    return "將水轉化為治療";
                case "ko":
                    return "물을 회복으로 변환하기";
                case "es":
                    return "Convertir agua en curación";
                case "fr":
                    return "Convertir l'eau en guérison";
                case "de":
                    return "Wasser in Heilung umwandeln";
                case "it":
                    return "Convertire l'acqua in cura";
                case "pt":
                    return "Converter água em cura";
                case "ru":
                    return "Преобразовать воду в исцеление";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "ランダムで木を火に変換する")
        {
            switch (langCode)
            {
                case "ja":
                    return "ランダムで木を火に変換する";
                case "en":
                    return "Convert wood to fire";
                case "zh-cn":
                    return "将木转化为火";
                case "zh-tw":
                    return "將木轉化為火";
                case "ko":
                    return "나무를 불로 변환하기";
                case "es":
                    return "Convertir madera en fuego";
                case "fr":
                    return "Convertir le bois en feu";
                case "de":
                    return "Holz in Feuer umwandeln";
                case "it":
                    return "Convertire il legno in fuoco";
                case "pt":
                    return "Converter madeira em fogo";
                case "ru":
                    return "Преобразовать дерево в огонь";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "ランダムで木を水に変換する")
        {
            switch (langCode)
            {
                case "ja":
                    return "ランダムで木を水に変換する";
                case "en":
                    return "Convert wood to water";
                case "zh-cn":
                    return "将木转化为水";
                case "zh-tw":
                    return "將木轉化為水";
                case "ko":
                    return "나무를 물로 변환하기";
                case "es":
                    return "Convertir madera en agua";
                case "fr":
                    return "Convertir le bois en eau";
                case "de":
                    return "Holz in Wasser umwandeln";
                case "it":
                    return "Convertire il legno in acqua";
                case "pt":
                    return "Converter madeira em água";
                case "ru":
                    return "Преобразовать дерево в воду";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "ランダムで木を回復に変換する")
        {
            switch (langCode)
            {
                case "ja":
                    return "ランダムで木を回復に変換する";
                case "en":
                    return "Convert wood to healing";
                case "zh-cn":
                    return "将木转化为治疗";
                case "zh-tw":
                    return "將木轉化為治療";
                case "ko":
                    return "나무를 회복으로 변환하기";
                case "es":
                    return "Convertir madera en curación";
                case "fr":
                    return "Convertir le bois en guérison";
                case "de":
                    return "Holz in Heilung umwandeln";
                case "it":
                    return "Convertire il legno in cura";
                case "pt":
                    return "Converter madeira em cura";
                case "ru":
                    return "Преобразовать дерево в исцеление";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "ランダムで回復を火に変換する")
        {
            switch (langCode)
            {
                case "ja":
                    return "ランダムで回復を火に変換する";
                case "en":
                    return "Convert healing to fire";
                case "zh-cn":
                    return "将治疗转化为火";
                case "zh-tw":
                    return "將治療轉化為火";
                case "ko":
                    return "회복을 불로 변환하기";
                case "es":
                    return "Convertir curación en fuego";
                case "fr":
                    return "Convertir la guérison en feu";
                case "de":
                    return "Heilung in Feuer umwandeln";
                case "it":
                    return "Convertire la cura in fuoco";
                case "pt":
                    return "Converter cura em fogo";
                case "ru":
                    return "Преобразовать исцеление в огонь";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "ランダムで回復を水に変換する")
        {
            switch (langCode)
            {
                case "ja":
                    return "ランダムで回復を水に変換する";
                case "en":
                    return "Convert healing to water";
                case "zh-cn":
                    return "将治疗转化为水";
                case "zh-tw":
                    return "將治療轉化為水";
                case "ko":
                    return "회복을 물로 변환하기";
                case "es":
                    return "Convertir curación en agua";
                case "fr":
                    return "Convertir la guérison en eau";
                case "de":
                    return "Heilung in Wasser umwandeln";
                case "it":
                    return "Convertire la cura in acqua";
                case "pt":
                    return "Converter cura em água";
                case "ru":
                    return "Преобразовать исцеление в воду";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "ランダムで回復を木に変換する")
        {
            switch (langCode)
            {
                case "ja":
                    return "ランダムで回復を木に変換する";
                case "en":
                    return "Convert healing to wood";
                case "zh-cn":
                    return "将治疗转化为木";
                case "zh-tw":
                    return "將治療轉化為木";
                case "ko":
                    return "회복을 나무로 변환하기";
                case "es":
                    return "Convertir curación en madera";
                case "fr":
                    return "Convertir la guérison en bois";
                case "de":
                    return "Heilung in Holz umwandeln";
                case "it":
                    return "Convertire la cura in legno";
                case "pt":
                    return "Converter cura em madeira";
                case "ru":
                    return "Преобразовать исцеление в дерево";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "攻撃力を1.2倍にする")
        {
            switch (langCode)
            {
                case "ja":
                    return "攻撃力を1.2倍にする";
                case "en":
                    return "Increase attack power by 1.2 times";
                case "zh-cn":
                    return "将攻击力提高1.2倍";
                case "zh-tw":
                    return "將攻擊力提高1.2倍";
                case "ko":
                    return "공격력을 1.2배로 증가";
                case "es":
                    return "Aumentar el poder de ataque en 1.2 veces";
                case "fr":
                    return "Augmenter la puissance d'attaque de 1.2 fois";
                case "de":
                    return "Erhöhe die Angriffskraft um 1,2 Mal";
                case "it":
                    return "Aumenta la potenza d'attacco del 1.2 volte";
                case "pt":
                    return "Aumentar o poder de ataque em 1,2 vezes";
                case "ru":
                    return "Увеличьте силу атаки в 1.2 раза";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "攻撃力を1.5倍にする")
        {
            switch (langCode)
            {
                case "ja":
                    return "攻撃力を1.5倍にする";
                case "en":
                    return "Increase attack power by 1.5 times";
                case "zh-cn":
                    return "将攻击力提高1.5倍";
                case "zh-tw":
                    return "將攻擊力提高1.5倍";
                case "ko":
                    return "공격력을 1.5배로 증가";
                case "es":
                    return "Aumentar el poder de ataque en 1.5 veces";
                case "fr":
                    return "Augmenter la puissance d'attaque de 1.5 fois";
                case "de":
                    return "Erhöhe die Angriffskraft um 1,5 Mal";
                case "it":
                    return "Aumenta la potenza d'attacco del 1.5 volte";
                case "pt":
                    return "Aumentar o poder de ataque em 1,5 vezes";
                case "ru":
                    return "Увеличьте силу атаки в 1.5 раза";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "回復力を1.2倍にする")
        {
            switch (langCode)
            {
                case "ja":
                    return "回復力を1.2倍にする";
                case "en":
                    return "Increase healing power by 1.2 times";
                case "zh-cn":
                    return "将治疗能力提高1.2倍";
                case "zh-tw":
                    return "將治療能力提高1.2倍";
                case "ko":
                    return "회복 능력을 1.2배로 증가";
                case "es":
                    return "Aumentar el poder de curación en 1.2 veces";
                case "fr":
                    return "Augmenter la puissance de guérison de 1.2 fois";
                case "de":
                    return "Erhöhe die Heilkraft um 1,2 Mal";
                case "it":
                    return "Aumenta la potenza di cura del 1.2 volte";
                case "pt":
                    return "Aumentar o poder de cura em 1,2 vezes";
                case "ru":
                    return "Увеличьте силу исцеления в 1.2 раза";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "回復力を1.5倍にする")
        {
            switch (langCode)
            {
                case "ja":
                    return "回復力を1.5倍にする";
                case "en":
                    return "Increase healing power by 1.5 times";
                case "zh-cn":
                    return "将治疗能力提高1.5倍";
                case "zh-tw":
                    return "將治療能力提高1.5倍";
                case "ko":
                    return "회복 능력을 1.5배로 증가";
                case "es":
                    return "Aumentar el poder de curación en 1.5 veces";
                case "fr":
                    return "Augmenter la puissance de guérison de 1.5 fois";
                case "de":
                    return "Erhöhe die Heilkraft um 1,5 Mal";
                case "it":
                    return "Aumenta la potenza di cura del 1.5 volte";
                case "pt":
                    return "Aumentar o poder de cura em 1,5 vezes";
                case "ru":
                    return "Увеличьте силу исцеления в 1.5 раза";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "HPを30%回復する")
        {
            switch (langCode)
            {
                case "ja":
                    return "HPを30%回復する";
                case "en":
                    return "Restore HP by 30%";
                case "zh-cn":
                    return "恢复30%的HP";
                case "zh-tw":
                    return "恢復30%的HP";
                case "ko":
                    return "HP를 30% 회복";
                case "es":
                    return "Restaurar HP en un 30%";
                case "fr":
                    return "Restaurer HP de 30%";
                case "de":
                    return "HP um 30% wiederherstellen";
                case "it":
                    return "Ripristina l'HP del 30%";
                case "pt":
                    return "Restaurar HP em 30%";
                case "ru":
                    return "Восстановить HP на 30%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "HPを50%回復する")
        {
            switch (langCode)
            {
                case "ja":
                    return "HPを50%回復する";
                case "en":
                    return "Restore HP by 50%";
                case "zh-cn":
                    return "恢复50%的HP";
                case "zh-tw":
                    return "恢復50%的HP";
                case "ko":
                    return "HP를 50% 회복";
                case "es":
                    return "Restaurar HP en un 50%";
                case "fr":
                    return "Restaurer HP de 50%";
                case "de":
                    return "HP um 50% wiederherstellen";
                case "it":
                    return "Ripristina l'HP del 50%";
                case "pt":
                    return "Restaurar HP em 50%";
                case "ru":
                    return "Восстановить HP на 50%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "パラメータ異常を治す")
        {
            switch (langCode)
            {
                case "ja":
                    return "パラメータ異常を治す";
                case "en":
                    return "Cure parameter abnormality";
                case "zh-cn":
                    return "治疗参数异常";
                case "zh-tw":
                    return "治療參數異常";
                case "ko":
                    return "파라미터 이상을 치료";
                case "es":
                    return "Curar anormalidad de parámetros";
                case "fr":
                    return "Guérir l'anomalie des paramètres";
                case "de":
                    return "Parameteranomalie heilen";
                case "it":
                    return "Curare l'anomalia dei parametri";
                case "pt":
                    return "Curar anormalidade de parâmetros";
                case "ru":
                    return "Излечить параметрическое отклонение";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "状態異常を治す")
        {
            switch (langCode)
            {
                case "ja":
                    return "状態異常を治す";
                case "en":
                    return "Cure status abnormalities";
                case "zh-cn":
                    return "治疗状态异常";
                case "zh-tw":
                    return "治療狀態異常";
                case "ko":
                    return "상태 이상을 치료";
                case "es":
                    return "Curar anomalías de estado";
                case "fr":
                    return "Guérir les anomalies de l'état";
                case "de":
                    return "Statusanomalien heilen";
                case "it":
                    return "Curare anomalie di stato";
                case "pt":
                    return "Curar anomalias de estado";
                case "ru":
                    return "Излечить нарушения состояния";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "火属性に与えるダメージ+2%")
        {
            switch (langCode)
            {
                case "ja":
                    return "火属性に与えるダメージ+2%";
                case "en":
                    return "Damage to fire attributes +2%";
                case "zh-cn":
                    return "对火属性造成伤害+2%";
                case "zh-tw":
                    return "對火屬性造成傷害+2%";
                case "ko":
                    return "불 속성에 대한 데미지 +2%";
                case "es":
                    return "Daño a atributos de fuego +2%";
                case "fr":
                    return "Dommages aux attributs de feu +2%";
                case "de":
                    return "Schaden an Feuereigenschaften +2%";
                case "it":
                    return "Danno agli attributi del fuoco +2%";
                case "pt":
                    return "Dano aos atributos de fogo +2%";
                case "ru":
                    return "Урон огненным атрибутам +2%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "火属性に与えるダメージ+5%")
        {
            switch (langCode)
            {
                case "ja":
                    return "火属性に与えるダメージ+5%";
                case "en":
                    return "Damage to fire attributes +5%";
                case "zh-cn":
                    return "对火属性造成伤害+5%";
                case "zh-tw":
                    return "對火屬性造成傷害+5%";
                case "ko":
                    return "불 속성에 대한 데미지 +5%";
                case "es":
                    return "Daño a atributos de fuego +5%";
                case "fr":
                    return "Dommages aux attributs de feu +5%";
                case "de":
                    return "Schaden an Feuereigenschaften +5%";
                case "it":
                    return "Danno agli attributi del fuoco +5%";
                case "pt":
                    return "Dano aos atributos de fogo +5%";
                case "ru":
                    return "Урон огненным атрибутам +5%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "水属性に与えるダメージ+2%")
        {
            switch (langCode)
            {
                case "ja":
                    return "水属性に与えるダメージ+2%";
                case "en":
                    return "Damage to water attributes +2%";
                case "zh-cn":
                    return "对水属性造成伤害+2%";
                case "zh-tw":
                    return "對水屬性造成傷害+2%";
                case "ko":
                    return "물 속성에 대한 데미지 +2%";
                case "es":
                    return "Daño a atributos de agua +2%";
                case "fr":
                    return "Dommages aux attributs de l'eau +2%";
                case "de":
                    return "Schaden an Wassereigenschaften +2%";
                case "it":
                    return "Danno agli attributi dell'acqua +2%";
                case "pt":
                    return "Dano aos atributos de água +2%";
                case "ru":
                    return "Урон водным атрибутам +2%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "水属性に与えるダメージ+5%")
        {
            switch (langCode)
            {
                case "ja":
                    return "水属性に与えるダメージ+5%";
                case "en":
                    return "Damage to water attributes +5%";
                case "zh-cn":
                    return "对水属性造成伤害+5%";
                case "zh-tw":
                    return "對水屬性造成傷害+5%";
                case "ko":
                    return "물 속성에 대한 데미지 +5%";
                case "es":
                    return "Daño a atributos de agua +5%";
                case "fr":
                    return "Dommages aux attributs de l'eau +5%";
                case "de":
                    return "Schaden an Wassereigenschaften +5%";
                case "it":
                    return "Danno agli attributi dell'acqua +5%";
                case "pt":
                    return "Dano aos atributos de água +5%";
                case "ru":
                    return "Урон водным атрибутам +5%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "木属性に与えるダメージ+2%")
        {
            switch (langCode)
            {
                case "ja":
                    return "木属性に与えるダメージ+2%";
                case "en":
                    return "Damage to wood attributes +2%";
                case "zh-cn":
                    return "对木属性造成伤害+2%";
                case "zh-tw":
                    return "對木屬性造成傷害+2%";
                case "ko":
                    return "나무 속성에 대한 데미지 +2%";
                case "es":
                    return "Daño a atributos de madera +2%";
                case "fr":
                    return "Dommages aux attributs du bois +2%";
                case "de":
                    return "Schaden an Holzeigenschaften +2%";
                case "it":
                    return "Danno agli attributi del legno +2%";
                case "pt":
                    return "Dano aos atributos de madeira +2%";
                case "ru":
                    return "Урон древесным атрибутам +2%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "木属性に与えるダメージ+5%")
        {
            switch (langCode)
            {
                case "ja":
                    return "木属性に与えるダメージ+5%";
                case "en":
                    return "Damage to wood attributes +5%";
                case "zh-cn":
                    return "对木属性造成伤害+5%";
                case "zh-tw":
                    return "對木屬性造成傷害+5%";
                case "ko":
                    return "나무 속성에 대한 데미지 +5%";
                case "es":
                    return "Daño a atributos de madera +5%";
                case "fr":
                    return "Dommages aux attributs du bois +5%";
                case "de":
                    return "Schaden an Holzeigenschaften +5%";
                case "it":
                    return "Danno agli attributi del legno +5%";
                case "pt":
                    return "Dano aos atributos de madeira +5%";
                case "ru":
                    return "Урон древесным атрибутам +5%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "パーツを10個以上消すとダメージ+1%")
        {
            switch (langCode)
            {
                case "ja":
                    return "パーツを10個以上消すとダメージ+1%";
                case "en":
                    return "Damage +1% when clearing 10 or more parts";
                case "zh-cn":
                    return "清除10个或更多零件时，伤害+1%";
                case "zh-tw":
                    return "消除10個或更多零件時，傷害+1%";
                case "ko":
                    return "10개 이상의 부품을 제거하면 데미지 +1%";
                case "es":
                    return "Daño +1% al eliminar 10 o más piezas";
                case "fr":
                    return "Dommages +1% en effaçant 10 pièces ou plus";
                case "de":
                    return "Schaden +1%, wenn 10 oder mehr Teile entfernt werden";
                case "it":
                    return "Danno +1% quando si eliminano 10 o più parti";
                case "pt":
                    return "Dano +1% ao limpar 10 ou mais peças";
                case "ru":
                    return "Урон +1% при удалении 10 или более деталей";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "パーツを20個以上消すとダメージ+3%")
        {
            switch (langCode)
            {
                case "ja":
                    return "パーツを20個以上消すとダメージ+3%";
                case "en":
                    return "Damage +3% when clearing 20 or more parts";
                case "zh-cn":
                    return "清除20个或更多零件时，伤害+3%";
                case "zh-tw":
                    return "消除20個或更多零件時，傷害+3%";
                case "ko":
                    return "20개 이상의 부품을 제거하면 데미지 +3%";
                case "es":
                    return "Daño +3% al eliminar 20 o más piezas";
                case "fr":
                    return "Dommages +3% en effaçant 20 pièces ou plus";
                case "de":
                    return "Schaden +3%, wenn 20 oder mehr Teile entfernt werden";
                case "it":
                    return "Danno +3% quando si eliminano 20 o più parti";
                case "pt":
                    return "Dano +3% ao limpar 20 ou mais peças";
                case "ru":
                    return "Урон +3% при удалении 20 или более деталей";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "パーツを30個以上消すとダメージ+6%")
        {
            switch (langCode)
            {
                case "ja":
                    return "パーツを30個以上消すとダメージ+6%";
                case "en":
                    return "Damage +6% when clearing 30 or more parts";
                case "zh-cn":
                    return "清除30个或更多零件时，伤害+6%";
                case "zh-tw":
                    return "消除30個或更多零件時，傷害+6%";
                case "ko":
                    return "30개 이상의 부품을 제거하면 데미지 +6%";
                case "es":
                    return "Daño +6% al eliminar 30 o más piezas";
                case "fr":
                    return "Dommages +6% en effaçant 30 pièces ou plus";
                case "de":
                    return "Schaden +6%, wenn 30 oder mehr Teile entfernt werden";
                case "it":
                    return "Danno +6% quando si eliminano 30 o più parti";
                case "pt":
                    return "Dano +6% ao limpar 30 ou mais peças";
                case "ru":
                    return "Урон +6% при удалении 30 или более деталей";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "パーツを40個以上消すとダメージ+10%")
        {
            switch (langCode)
            {
                case "ja":
                    return "パーツを40個以上消すとダメージ+10%";
                case "en":
                    return "Damage +10% when clearing 40 or more parts";
                case "zh-cn":
                    return "清除40个或更多零件时，伤害+10%";
                case "zh-tw":
                    return "消除40個或更多零件時，傷害+10%";
                case "ko":
                    return "40개 이상의 부품을 제거하면 데미지 +10%";
                case "es":
                    return "Daño +10% al eliminar 40 o más piezas";
                case "fr":
                    return "Dommages +10% en effaçant 40 pièces ou plus";
                case "de":
                    return "Schaden +10%, wenn 40 oder mehr Teile entfernt werden";
                case "it":
                    return "Danno +10% quando si eliminano 40 o più parti";
                case "pt":
                    return "Dano +10% ao limpar 40 ou mais peças";
                case "ru":
                    return "Урон +10% при удалении 40 или более деталей";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "パーツを50個以上消すとダメージ+20%")
        {
            switch (langCode)
            {
                case "ja":
                    return "パーツを50個以上消すとダメージ+20%";
                case "en":
                    return "Damage +20% when clearing 50 or more parts";
                case "zh-cn":
                    return "清除50个或更多零件时，伤害+20%";
                case "zh-tw":
                    return "消除50個或更多零件時，傷害+20%";
                case "ko":
                    return "50개 이상의 부품을 제거하면 데미지 +20%";
                case "es":
                    return "Daño +20% al eliminar 50 o más piezas";
                case "fr":
                    return "Dommages +20% en effaçant 50 pièces ou plus";
                case "de":
                    return "Schaden +20%, wenn 50 oder mehr Teile entfernt werden";
                case "it":
                    return "Danno +20% quando si eliminano 50 o più parti";
                case "pt":
                    return "Dano +20% ao limpar 50 ou mais peças";
                case "ru":
                    return "Урон +20% при удалении 50 или более деталей";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "HPが50%以下のとき与えるダメージ+5%")
        {
            switch (langCode)
            {
                case "ja":
                    return "HPが50%以下のとき与えるダメージ+5%";
                case "en":
                    return "Damage +5% when HP is 50% or lower";
                case "zh-cn":
                    return "当HP为50%或更低时，伤害+5%";
                case "zh-tw":
                    return "當HP為50%或更低時，傷害+5%";
                case "ko":
                    return "HP가 50% 이하 일 때 데미지 +5%";
                case "es":
                    return "Daño +5% cuando la HP está al 50% o menos";
                case "fr":
                    return "Dommages +5% lorsque les HP sont à 50% ou moins";
                case "de":
                    return "Schaden +5%, wenn HP bei 50% oder weniger liegt";
                case "it":
                    return "Danno +5% quando l'HP è al 50% o meno";
                case "pt":
                    return "Dano +5% quando a HP estiver a 50% ou menos";
                case "ru":
                    return "Урон +5%, когда HP равен 50% или меньше";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "HPが25%以下のとき与えるダメージ+10%")
        {
            switch (langCode)
            {
                case "ja":
                    return "HPが25%以下のとき与えるダメージ+10%";
                case "en":
                    return "Damage +10% when HP is 25% or lower";
                case "zh-cn":
                    return "当HP为25%或更低时，伤害+10%";
                case "zh-tw":
                    return "當HP為25%或更低時，傷害+10%";
                case "ko":
                    return "HP가 25% 이하 일 때 데미지 +10%";
                case "es":
                    return "Daño +10% cuando la HP está al 25% o menos";
                case "fr":
                    return "Dommages +10% lorsque les HP sont à 25% ou moins";
                case "de":
                    return "Schaden +10%, wenn HP bei 25% oder weniger liegt";
                case "it":
                    return "Danno +10% quando l'HP è al 25% o meno";
                case "pt":
                    return "Dano +10% quando a HP estiver a 25% ou menos";
                case "ru":
                    return "Урон +10%, когда HP равен 25% или меньше";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "状態異常のとき与えるダメージ+5%")
        {
            switch (langCode)
            {
                case "ja":
                    return "状態異常のとき与えるダメージ+5%";
                case "en":
                    return "Damage +5% when inflicted with a status ailment";
                case "zh-cn":
                    return "受到状态异常时，伤害+5%";
                case "zh-tw":
                    return "受到狀態異常時，傷害+5%";
                case "ko":
                    return "상태이상에 걸릴 때 데미지 +5%";
                case "es":
                    return "Daño +5% cuando se sufre una condición anormal";
                case "fr":
                    return "Dommages +5% lorsqu'une altération d'état est infligée";
                case "de":
                    return "Schaden +5%, wenn ein Statusleiden verursacht wird";
                case "it":
                    return "Danno +5% quando viene inflitta una condizione anormale";
                case "pt":
                    return "Dano +5% quando afetado por uma condição anormal";
                case "ru":
                    return "Урон +5% при наличии статусного состояния";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "状態異常のとき与えるダメージ+10%")
        {
            switch (langCode)
            {
                case "ja":
                    return "状態異常のとき与えるダメージ+10%";
                case "en":
                    return "Damage +10% when inflicted with a status ailment";
                case "zh-cn":
                    return "受到状态异常时，伤害+10%";
                case "zh-tw":
                    return "受到狀態異常時，傷害+10%";
                case "ko":
                    return "상태이상에 걸릴 때 데미지 +10%";
                case "es":
                    return "Daño +10% cuando se sufre una condición anormal";
                case "fr":
                    return "Dommages +10% lorsqu'une altération d'état est infligée";
                case "de":
                    return "Schaden +10%, wenn ein Statusleiden verursacht wird";
                case "it":
                    return "Danno +10% quando viene inflitta una condizione anormale";
                case "pt":
                    return "Dano +10% quando afetado por uma condição anormal";
                case "ru":
                    return "Урон +10% при наличии статусного состояния";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "状態異常のときHP回復量+5%")
        {
            switch (langCode)
            {
                case "ja":
                    return "状態異常のときHP回復量+5%";
                case "en":
                    return "HP recovery +5% when inflicted with a status ailment";
                case "zh-cn":
                    return "受到状态异常时，HP恢复+5%";
                case "zh-tw":
                    return "受到狀態異常時，HP恢復+5%";
                case "ko":
                    return "상태이상에 걸릴 때 HP 회복 +5%";
                case "es":
                    return "Recuperación de HP +5% cuando se sufre una condición anormal";
                case "fr":
                    return "Récupération de HP +5% lorsqu'une altération d'état est infligée";
                case "de":
                    return "HP-Wiederherstellung +5%, wenn ein Statusleiden verursacht wird";
                case "it":
                    return "Ripristino HP +5% quando viene inflitta una condizione anormale";
                case "pt":
                    return "Recuperação de HP +5% quando afetado por uma condição anormal";
                case "ru":
                    return "Восстановление HP +5% при наличии статусного состояния";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "状態異常のときHP回復量+10%")
        {
            switch (langCode)
            {
                case "ja":
                    return "状態異常のときHP回復量+10%";
                case "en":
                    return "HP recovery +10% when inflicted with a status ailment";
                case "zh-cn":
                    return "受到状态异常时，HP恢复+10%";
                case "zh-tw":
                    return "受到狀態異常時，HP恢復+10%";
                case "ko":
                    return "상태이상에 걸릴 때 HP 회복 +10%";
                case "es":
                    return "Recuperación de HP +10% cuando se sufre una condición anormal";
                case "fr":
                    return "Récupération de HP +10% lorsqu'une altération d'état est infligée";
                case "de":
                    return "HP-Wiederherstellung +10%, wenn ein Statusleiden verursacht wird";
                case "it":
                    return "Ripristino HP +10% quando viene inflitta una condizione anormale";
                case "pt":
                    return "Recuperação de HP +10% quando afetado por uma condição anormal";
                case "ru":
                    return "Восстановление HP +10% при наличии статусного состояния";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "火属性から受けるダメージ-2%")
        {
            switch (langCode)
            {
                case "ja":
                    return "火属性から受けるダメージ-2%";
                case "en":
                    return "Damage received from fire attribute -2%";
                case "zh-cn":
                    return "从火属性受到的伤害-2%";
                case "zh-tw":
                    return "從火屬性受到的傷害-2%";
                case "ko":
                    return "화염 속성에서 받는 데미지 -2%";
                case "es":
                    return "Daño recibido de la atributo de fuego -2%";
                case "fr":
                    return "Dommages reçus de l'attribut feu -2%";
                case "de":
                    return "Schaden durch Feuerattribut -2%";
                case "it":
                    return "Danno ricevuto dall'attributo fuoco -2%";
                case "pt":
                    return "Dano recebido do atributo de fogo -2%";
                case "ru":
                    return "Урон от огненного атрибута -2%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "火属性から受けるダメージ-5%")
        {
            switch (langCode)
            {
                case "ja":
                    return "火属性から受けるダメージ-5%";
                case "en":
                    return "Damage received from fire attribute -5%";
                case "zh-cn":
                    return "从火属性受到的伤害-5%";
                case "zh-tw":
                    return "從火屬性受到的傷害-5%";
                case "ko":
                    return "화염 속성에서 받는 데미지 -5%";
                case "es":
                    return "Daño recibido de la atributo de fuego -5%";
                case "fr":
                    return "Dommages reçus de l'attribut feu -5%";
                case "de":
                    return "Schaden durch Feuerattribut -5%";
                case "it":
                    return "Danno ricevuto dall'attributo fuoco -5%";
                case "pt":
                    return "Dano recebido do atributo de fogo -5%";
                case "ru":
                    return "Урон от огненного атрибута -5%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "水属性から受けるダメージ-2%")
        {
            switch (langCode)
            {
                case "ja":
                    return "水属性から受けるダメージ-2%";
                case "en":
                    return "Damage received from water attribute -2%";
                case "zh-cn":
                    return "从水属性受到的伤害-2%";
                case "zh-tw":
                    return "從水屬性受到的傷害-2%";
                case "ko":
                    return "물 속성에서 받는 데미지 -2%";
                case "es":
                    return "Daño recibido de la atributo de agua -2%";
                case "fr":
                    return "Dommages reçus de l'attribut eau -2%";
                case "de":
                    return "Schaden durch Wasserattribut -2%";
                case "it":
                    return "Danno ricevuto dall'attributo acqua -2%";
                case "pt":
                    return "Dano recebido do atributo de água -2%";
                case "ru":
                    return "Урон от водного атрибута -2%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "水属性から受けるダメージ-5%")
        {
            switch (langCode)
            {
                case "ja":
                    return "水属性から受けるダメージ-5%";
                case "en":
                    return "Damage received from water attribute -5%";
                case "zh-cn":
                    return "从水属性受到的伤害-5%";
                case "zh-tw":
                    return "從水屬性受到的傷害-5%";
                case "ko":
                    return "물 속성에서 받는 데미지 -5%";
                case "es":
                    return "Daño recibido de la atributo de agua -5%";
                case "fr":
                    return "Dommages reçus de l'attribut eau -5%";
                case "de":
                    return "Schaden durch Wasserattribut -5%";
                case "it":
                    return "Danno ricevuto dall'attributo acqua -5%";
                case "pt":
                    return "Dano recebido do atributo de água -5%";
                case "ru":
                    return "Урон от водного атрибута -5%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "木属性から受けるダメージ-2%")
        {
            switch (langCode)
            {
                case "ja":
                    return "木属性から受けるダメージ-2%";
                case "en":
                    return "Damage received from wood attribute -2%";
                case "zh-cn":
                    return "从木属性受到的伤害-2%";
                case "zh-tw":
                    return "從木屬性受到的傷害-2%";
                case "ko":
                    return "나무 속성에서 받는 데미지 -2%";
                case "es":
                    return "Daño recibido de la atributo de madera -2%";
                case "fr":
                    return "Dommages reçus de l'attribut bois -2%";
                case "de":
                    return "Schaden durch Holzattribut -2%";
                case "it":
                    return "Danno ricevuto dall'attributo legno -2%";
                case "pt":
                    return "Dano recebido do atributo de madeira -2%";
                case "ru":
                    return "Урон от деревянного атрибута -2%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "木属性から受けるダメージ-5%")
        {
            switch (langCode)
            {
                case "ja":
                    return "木属性から受けるダメージ-5%";
                case "en":
                    return "Damage received from wood attribute -5%";
                case "zh-cn":
                    return "从木属性受到的伤害-5%";
                case "zh-tw":
                    return "從木屬性受到的傷害-5%";
                case "ko":
                    return "나무 속성에서 받는 데미지 -5%";
                case "es":
                    return "Daño recibido de la atributo de madera -5%";
                case "fr":
                    return "Dommages reçus de l'attribut bois -5%";
                case "de":
                    return "Schaden durch Holzattribut -5%";
                case "it":
                    return "Danno ricevuto dall'attributo legno -5%";
                case "pt":
                    return "Dano recebido do atributo de madeira -5%";
                case "ru":
                    return "Урон от деревянного атрибута -5%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "パラメータ異常にかかる確率-10%")
        {
            switch (langCode)
            {
                case "ja":
                    return "パラメータ異常にかかる確率-10%";
                case "en":
                    return "Probability of parameter abnormality -10%";
                case "zh-cn":
                    return "参数异常的概率-10%";
                case "zh-tw":
                    return "參數異常的概率-10%";
                case "ko":
                    return "파라미터 이상 발생 확률 -10%";
                case "es":
                    return "Probabilidad de anormalidad de parámetros -10%";
                case "fr":
                    return "Probabilité d'anomalie des paramètres -10%";
                case "de":
                    return "Wahrscheinlichkeit einer Parameteranomalie -10%";
                case "it":
                    return "Probabilità di anomalie dei parametri -10%";
                case "pt":
                    return "Probabilidade de anomalia de parâmetros -10%";
                case "ru":
                    return "Вероятность параметрической аномалии -10%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "パラメータ異常にかかる確率-20%")
        {
            switch (langCode)
            {
                case "ja":
                    return "パラメータ異常にかかる確率-20%";
                case "en":
                    return "Probability of parameter abnormality -20%";
                case "zh-cn":
                    return "参数异常的概率-20%";
                case "zh-tw":
                    return "參數異常的概率-20%";
                case "ko":
                    return "파라미터 이상 발생 확률 -20%";
                case "es":
                    return "Probabilidad de anormalidad de parámetros -20%";
                case "fr":
                    return "Probabilité d'anomalie des paramètres -20%";
                case "de":
                    return "Wahrscheinlichkeit einer Parameteranomalie -20%";
                case "it":
                    return "Probabilità di anomalie dei parametri -20%";
                case "pt":
                    return "Probabilidade de anomalia de parâmetros -20%";
                case "ru":
                    return "Вероятность параметрической аномалии -20%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "パラメータ異常にかかる確率-30%")
        {
            switch (langCode)
            {
                case "ja":
                    return "パラメータ異常にかかる確率-30%";
                case "en":
                    return "Probability of parameter abnormality -30%";
                case "zh-cn":
                    return "参数异常的概率-30%";
                case "zh-tw":
                    return "參數異常的概率-30%";
                case "ko":
                    return "파라미터 이상 발생 확률 -30%";
                case "es":
                    return "Probabilidad de anormalidad de parámetros -30%";
                case "fr":
                    return "Probabilité d'anomalie des paramètres -30%";
                case "de":
                    return "Wahrscheinlichkeit einer Parameteranomalie -30%";
                case "it":
                    return "Probabilità di anomalie dei parametri -30%";
                case "pt":
                    return "Probabilidade de anomalia de parâmetros -30%";
                case "ru":
                    return "Вероятность параметрической аномалии -30%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "状態異常にかかる確率-10%")
        {
            switch (langCode)
            {
                case "ja":
                    return "状態異常にかかる確率-10%";
                case "en":
                    return "Probability of status abnormality -10%";
                case "zh-cn":
                    return "状态异常的概率-10%";
                case "zh-tw":
                    return "狀態異常的概率-10%";
                case "ko":
                    return "상태 이상 발생 확률 -10%";
                case "es":
                    return "Probabilidad de anormalidad de estado -10%";
                case "fr":
                    return "Probabilité d'anomalie d'état -10%";
                case "de":
                    return "Wahrscheinlichkeit eines Zustandsanomalie -10%";
                case "it":
                    return "Probabilità di anomalia dello stato -10%";
                case "pt":
                    return "Probabilidade de anomalia de estado -10%";
                case "ru":
                    return "Вероятность состояния аномалии -10%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "状態異常にかかる確率-20%")
        {
            switch (langCode)
            {
                case "ja":
                    return "状態異常にかかる確率-20%";
                case "en":
                    return "Probability of status abnormality -20%";
                case "zh-cn":
                    return "状态异常的概率-20%";
                case "zh-tw":
                    return "狀態異常的概率-20%";
                case "ko":
                    return "상태 이상 발생 확률 -20%";
                case "es":
                    return "Probabilidad de anormalidad de estado -20%";
                case "fr":
                    return "Probabilité d'anomalie d'état -20%";
                case "de":
                    return "Wahrscheinlichkeit eines Zustandsanomalie -20%";
                case "it":
                    return "Probabilità di anomalia dello stato -20%";
                case "pt":
                    return "Probabilidade de anomalia de estado -20%";
                case "ru":
                    return "Вероятность состояния аномалии -20%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "状態異常にかかる確率-30%")
        {
            switch (langCode)
            {
                case "ja":
                    return "状態異常にかかる確率-30%";
                case "en":
                    return "Probability of status abnormality -30%";
                case "zh-cn":
                    return "状态异常的概率-30%";
                case "zh-tw":
                    return "狀態異常的概率-30%";
                case "ko":
                    return "상태 이상 발생 확률 -30%";
                case "es":
                    return "Probabilidad de anormalidad de estado -30%";
                case "fr":
                    return "Probabilité d'anomalie d'état -30%";
                case "de":
                    return "Wahrscheinlichkeit eines Zustandsanomalie -30%";
                case "it":
                    return "Probabilità di anomalia dello stato -30%";
                case "pt":
                    return "Probabilidade de anomalia de estado -30%";
                case "ru":
                    return "Вероятность состояния аномалии -30%";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "毎ターンHPの1%を回復する")
        {
            switch (langCode)
            {
                case "ja":
                    return "毎ターンHPの1%を回復する";
                case "en":
                    return "Recover 1% of HP every turn";
                case "zh-cn":
                    return "每回合恢复1%的HP";
                case "zh-tw":
                    return "每回合恢復1%的HP";
                case "ko":
                    return "매 턴마다 HP의 1%를 회복합니다";
                case "es":
                    return "Recupera el 1% de HP cada turno";
                case "fr":
                    return "Récupère 1% de HP à chaque tour";
                case "de":
                    return "Wiederherstellung von 1% HP pro Runde";
                case "it":
                    return "Rigenera l'1% di HP ogni turno";
                case "pt":
                    return "Recupera 1% de HP a cada turno";
                case "ru":
                    return "Восстанавливает 1% HP каждый ход";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "毎ターンHPの3%を回復する")
        {
            switch (langCode)
            {
                case "ja":
                    return "毎ターンHPの3%を回復する";
                case "en":
                    return "Recover 3% of HP every turn";
                case "zh-cn":
                    return "每回合恢复3%的HP";
                case "zh-tw":
                    return "每回合恢復3%的HP";
                case "ko":
                    return "매 턴마다 HP의 3%를 회복합니다";
                case "es":
                    return "Recupera el 3% de HP cada turno";
                case "fr":
                    return "Récupère 3% de HP à chaque tour";
                case "de":
                    return "Wiederherstellung von 3% HP pro Runde";
                case "it":
                    return "Rigenera il 3% di HP ogni turno";
                case "pt":
                    return "Recupera 3% de HP a cada turno";
                case "ru":
                    return "Восстанавливает 3% HP каждый ход";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "HPが0になったとき5%の確率で生き残る")
        {
            switch (langCode)
            {
                case "ja":
                    return "HPが0になったとき5%の確率で生き残る";
                case "en":
                    return "5% chance to survive when HP reaches 0";
                case "zh-cn":
                    return "HP达到0时有5%的存活几率";
                case "zh-tw":
                    return "HP達到0時有5%的存活機會";
                case "ko":
                    return "HP가 0이 될 때 5%의 생존 확률";
                case "es":
                    return "Probabilidad del 5% de sobrevivir cuando HP llega a 0";
                case "fr":
                    return "Chance de survie de 5% lorsque les HP atteignent 0";
                case "de":
                    return "5% Überlebenschance, wenn HP auf 0 fällt";
                case "it":
                    return "Probabilità del 5% di sopravvivenza quando HP raggiunge 0";
                case "pt":
                    return "Chance de sobreviver de 5% quando o HP chegar a 0";
                case "ru":
                    return "5% шанс выжить, когда HP достигает 0";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "HPが0になったとき10%の確率で生き残る")
        {
            switch (langCode)
            {
                case "ja":
                    return "HPが0になったとき10%の確率で生き残る";
                case "en":
                    return "10% chance to survive when HP reaches 0";
                case "zh-cn":
                    return "HP达到0时有10%的存活几率";
                case "zh-tw":
                    return "HP達到0時有10%的存活機會";
                case "ko":
                    return "HP가 0이 될 때 10%의 생존 확률";
                case "es":
                    return "Probabilidad del 10% de sobrevivir cuando HP llega a 0";
                case "fr":
                    return "Chance de survie de 10% lorsque les HP atteignent 0";
                case "de":
                    return "10% Überlebenschance, wenn HP auf 0 fällt";
                case "it":
                    return "Probabilità del 10% di sopravvivenza quando HP raggiunge 0";
                case "pt":
                    return "Chance de sobreviver de 10% quando o HP chegar a 0";
                case "ru":
                    return "10% шанс выжить, когда HP достигает 0";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "スキルが発動可能な状態でゲーム開始")
        {
            switch (langCode)
            {
                case "ja":
                    return "スキルが発動可能な状態でゲーム開始";
                case "en":
                    return "Start the game with skills ready to activate";
                case "zh-cn":
                    return "在技能准备好激活的情况下开始游戏";
                case "zh-tw":
                    return "在技能準備好啟動的情況下開始遊戲";
                case "ko":
                    return "스킬이 활성화 준비 상태로 게임을 시작합니다";
                case "es":
                    return "Comienza el juego con las habilidades listas para activar";
                case "fr":
                    return "Commencez le jeu avec les compétences prêtes à être activées";
                case "de":
                    return "Starte das Spiel mit bereiten Fertigkeiten zur Aktivierung";
                case "it":
                    return "Inizia il gioco con le abilità pronte per essere attivate";
                case "pt":
                    return "Comece o jogo com habilidades prontas para ativar";
                case "ru":
                    return "Начните игру с готовыми к активации навыками";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "毒")
        {
            switch (langCode)
            {
                case "ja":
                    return "毒";
                case "en":
                    return "Poison";
                case "zh-cn":
                    return "毒素";
                case "zh-tw":
                    return "毒素";
                case "ko":
                    return "독";
                case "es":
                    return "Veneno";
                case "fr":
                    return "Poison";
                case "de":
                    return "Gift";
                case "it":
                    return "Veleno";
                case "pt":
                    return "Veneno";
                case "ru":
                    return "Яд";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "麻痺")
        {
            switch (langCode)
            {
                case "ja":
                    return "麻痺";
                case "en":
                    return "Paralysis";
                case "zh-cn":
                    return "麻痹";
                case "zh-tw":
                    return "麻痺";
                case "ko":
                    return "마비";
                case "es":
                    return "Parálisis";
                case "fr":
                    return "Paralysie";
                case "de":
                    return "Lähmung";
                case "it":
                    return "Paralisi";
                case "pt":
                    return "Paralisia";
                case "ru":
                    return "Паралич";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "火傷")
        {
            switch (langCode)
            {
                case "ja":
                    return "火傷";
                case "en":
                    return "Burn";
                case "zh-cn":
                    return "烧伤";
                case "zh-tw":
                    return "燒傷";
                case "ko":
                    return "화상";
                case "es":
                    return "Quemadura";
                case "fr":
                    return "Brûlure";
                case "de":
                    return "Verbrennung";
                case "it":
                    return "Scottatura";
                case "pt":
                    return "Queimadura";
                case "ru":
                    return "Ожог";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "睡眠")
        {
            switch (langCode)
            {
                case "ja":
                    return "睡眠";
                case "en":
                    return "Sleep";
                case "zh-cn":
                    return "睡眠";
                case "zh-tw":
                    return "睡眠";
                case "ko":
                    return "수면";
                case "es":
                    return "Sueño";
                case "fr":
                    return "Sommeil";
                case "de":
                    return "Schlaf";
                case "it":
                    return "Sonno";
                case "pt":
                    return "Sono";
                case "ru":
                    return "Сон";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "暗闇")
        {
            switch (langCode)
            {
                case "ja":
                    return "暗闇";
                case "en":
                    return "Darkness";
                case "zh-cn":
                    return "黑暗";
                case "zh-tw":
                    return "黑暗";
                case "ko":
                    return "어둠";
                case "es":
                    return "Oscuridad";
                case "fr":
                    return "Obscurité";
                case "de":
                    return "Dunkelheit";
                case "it":
                    return "Oscurità";
                case "pt":
                    return "Escuridão";
                case "ru":
                    return "Тьма";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "混乱")
        {
            switch (langCode)
            {
                case "ja":
                    return "混乱";
                case "en":
                    return "Confusion";
                case "zh-cn":
                    return "混乱";
                case "zh-tw":
                    return "混亂";
                case "ko":
                    return "혼란";
                case "es":
                    return "Confusión";
                case "fr":
                    return "Confusion";
                case "de":
                    return "Verwirrung";
                case "it":
                    return "Confusione";
                case "pt":
                    return "Confusão";
                case "ru":
                    return "Путаница";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "攻撃力ダウン")
        {
            switch (langCode)
            {
                case "ja":
                    return "攻撃力ダウン";
                case "en":
                    return "Attack Down";
                case "zh-cn":
                    return "攻击下降";
                case "zh-tw":
                    return "攻擊下降";
                case "ko":
                    return "공격력 감소";
                case "es":
                    return "Disminución de Ataque";
                case "fr":
                    return "Réduction d'Attaque";
                case "de":
                    return "Angriff reduziert";
                case "it":
                    return "Diminuzione Attacco";
                case "pt":
                    return "Ataque Reduzido";
                case "ru":
                    return "Уменьшение атаки";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "回復力ダウン")
        {
            switch (langCode)
            {
                case "ja":
                    return "回復力ダウン";
                case "en":
                    return "Healing Down";
                case "zh-cn":
                    return "恢复下降";
                case "zh-tw":
                    return "恢復下降";
                case "ko":
                    return "회복력 감소";
                case "es":
                    return "Disminución de Curación";
                case "fr":
                    return "Réduction de Guérison";
                case "de":
                    return "Heilung reduziert";
                case "it":
                    return "Guarigione in Basso";
                case "pt":
                    return "Cura Reduzida";
                case "ru":
                    return "Уменьшение восстановления";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "攻撃力アップ")
        {
            switch (langCode)
            {
                case "ja":
                    return "攻撃力アップ";
                case "en":
                    return "Attack Up";
                case "zh-cn":
                    return "攻击上升";
                case "zh-tw":
                    return "攻擊上升";
                case "ko":
                    return "공격력 상승";
                case "es":
                    return "Aumento de Ataque";
                case "fr":
                    return "Augmentation de l'Attaque";
                case "de":
                    return "Angriff erhöht";
                case "it":
                    return "Aumento Attacco";
                case "pt":
                    return "Ataque Aumentado";
                case "ru":
                    return "Увеличение атаки";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "回復力アップ")
        {
            switch (langCode)
            {
                case "ja":
                    return "回復力アップ";
                case "en":
                    return "Healing Up";
                case "zh-cn":
                    return "恢复上升";
                case "zh-tw":
                    return "恢復上升";
                case "ko":
                    return "회복력 상승";
                case "es":
                    return "Aumento de Curación";
                case "fr":
                    return "Augmentation de Guérison";
                case "de":
                    return "Heilung erhöht";
                case "it":
                    return "Aumento Guarigione";
                case "pt":
                    return "Cura Aumentada";
                case "ru":
                    return "Увеличение восстановления";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "毎ターンHPの5%のダメージを受ける")
        {
            switch (langCode)
            {
                case "ja":
                    return "毎ターンHPの5%のダメージを受ける";
                case "en":
                    return "Take 5% HP damage every turn";
                case "zh-cn":
                    return "每回合受到5%的HP伤害";
                case "zh-tw":
                    return "每回合受到5%的HP傷害";
                case "ko":
                    return "매 턴마다 HP의 5% 데미지를 받습니다";
                case "es":
                    return "Recibir un 5% de daño HP cada turno";
                case "fr":
                    return "Prenez 5% de dégâts HP à chaque tour";
                case "de":
                    return "Nimm 5% HP-Schaden pro Runde";
                case "it":
                    return "Prendi un danno HP del 5% ogni turno";
                case "pt":
                    return "Receba 5% de dano HP a cada turno";
                case "ru":
                    return "Получайте урон HP на 5% каждый ход";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "ランダムでパネルの回転不可")
        {
            switch (langCode)
            {
                case "ja":
                    return "ランダムでパネルの回転不可";
                case "en":
                    return "Randomly panels cannot rotate";
                case "zh-cn":
                    return "随机面板无法旋转";
                case "zh-tw":
                    return "隨機面板無法旋轉";
                case "ko":
                    return "랜덤으로 패널 회전 불가";
                case "es":
                    return "Paneles no pueden rotar al azar";
                case "fr":
                    return "Les panneaux ne peuvent pas tourner aléatoirement";
                case "de":
                    return "Zufällig können sich die Paneele nicht drehen";
                case "it":
                    return "Pannelli non possono ruotare casualmente";
                case "pt":
                    return "Painéis não podem girar aleatoriamente";
                case "ru":
                    return "Панели не могут вращаться случайным образом";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "受けるダメージが1.5倍 特殊効果が無効")
        {
            switch (langCode)
            {
                case "ja":
                    return "受けるダメージが1.5倍 特殊効果が無効";
                case "en":
                    return "Take 1.5x damage. Special effects are disabled.";
                case "zh-cn":
                    return "受到1.5倍伤害。特效被禁用。";
                case "zh-tw":
                    return "受到1.5倍傷害。特效被禁用。";
                case "ko":
                    return "1.5배 데미지를 받습니다. 특수 효과가 비활성화됩니다.";
                case "es":
                    return "Recibe 1.5x de daño. Los efectos especiales están desactivados.";
                case "fr":
                    return "Prendre 1,5x de dégâts. Les effets spéciaux sont désactivés.";
                case "de":
                    return "Nimm 1,5-fachen Schaden. Spezialeffekte sind deaktiviert.";
                case "it":
                    return "Subisci 1,5x danni. Gli effetti speciali sono disabilitati.";
                case "pt":
                    return "Recebe 1,5x de dano. Os efeitos especiais estão desativados.";
                case "ru":
                    return "Получайте урон x1.5. Спецэффекты отключены.";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "与えるダメージが0倍 受けるダメージが2倍")
        {
            switch (langCode)
            {
                case "ja":
                    return "与えるダメージが0倍 受けるダメージが2倍";
                case "en":
                    return "Deal 0 damage. Take 2x damage.";
                case "zh-cn":
                    return "造成0伤害。受到2倍伤害。";
                case "zh-tw":
                    return "造成0傷害。受到2倍傷害。";
                case "ko":
                    return "데미지를 주지 않음. 2배 데미지를 받음.";
                case "es":
                    return "Causa 0 de daño. Recibe 2x de daño.";
                case "fr":
                    return "Inflige 0 dégâts. Prend 2x de dégâts.";
                case "de":
                    return "Verursacht 0 Schaden. Nimmt 2x Schaden.";
                case "it":
                    return "Infliggi 0 danni. Subisci 2x danni.";
                case "pt":
                    return "Causa 0 de dano. Recebe 2x de dano.";
                case "ru":
                    return "Наносит 0 урона. Получает 2x урона.";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "ランダムでパネルが見えなくなる")
        {
            switch (langCode)
            {
                case "ja":
                    return "ランダムでパネルが見えなくなる";
                case "en":
                    return "Randomly, panels become invisible.";
                case "zh-cn":
                    return "随机使面板不可见。";
                case "zh-tw":
                    return "隨機使面板不可見。";
                case "ko":
                    return "랜덤으로 패널이 보이지 않게 됩니다.";
                case "es":
                    return "De manera aleatoria, los paneles se vuelven invisibles.";
                case "fr":
                    return "De manière aléatoire, les panneaux deviennent invisibles.";
                case "de":
                    return "Zufällig werden die Panels unsichtbar.";
                case "it":
                    return "Casualmente, i pannelli diventano invisibili.";
                case "pt":
                    return "Aleatoriamente, os painéis ficam invisíveis.";
                case "ru":
                    return "Случайным образом панели становятся невидимыми.";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "回復パネルを消すとダメージを受ける")
        {
            switch (langCode)
            {
                case "ja":
                    return "回復パネルを消すとダメージを受ける";
                case "en":
                    return "Taking damage when removing recovery panels.";
                case "zh-cn":
                    return "移除恢复面板时受到伤害。";
                case "zh-tw":
                    return "移除恢復面板時受到傷害。";
                case "ko":
                    return "회복 패널을 제거하면 피해를 입습니다.";
                case "es":
                    return "Recibir daño al eliminar paneles de recuperación.";
                case "fr":
                    return "Prendre des dégâts en enlevant les panneaux de récupération.";
                case "de":
                    return "Schaden nehmen, wenn Heilungspanels entfernt werden.";
                case "it":
                    return "Subire danni quando si rimuovono i pannelli di recupero.";
                case "pt":
                    return "Sofrer dano ao remover painéis de recuperação.";
                case "ru":
                    return "Получение урона при удалении панелей восстановления.";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "攻撃力が0.5倍")
        {
            switch (langCode)
            {
                case "ja":
                    return "攻撃力が0.5倍";
                case "en":
                    return "Attack power is reduced to 0.5 times.";
                case "zh-cn":
                    return "攻击力减少到0.5倍。";
                case "zh-tw":
                    return "攻擊力減少到0.5倍。";
                case "ko":
                    return "공격력이 0.5배로 감소합니다.";
                case "es":
                    return "El poder de ataque se reduce a la mitad.";
                case "fr":
                    return "La puissance d'attaque est réduite de moitié.";
                case "de":
                    return "Die Angriffskraft wird auf 0,5 reduziert.";
                case "it":
                    return "La potenza d'attacco si riduce a 0,5 volte.";
                case "pt":
                    return "O poder de ataque é reduzido para 0,5 vezes.";
                case "ru":
                    return "Сила атаки уменьшается в 2 раза.";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "回復力が0.5倍")
        {
            switch (langCode)
            {
                case "ja":
                    return "回復力が0.5倍";
                case "en":
                    return "Recovery power is reduced to 0.5 times.";
                case "zh-cn":
                    return "恢复力减少到0.5倍。";
                case "zh-tw":
                    return "恢復力減少到0.5倍。";
                case "ko":
                    return "회복력이 0.5배로 감소합니다.";
                case "es":
                    return "La potencia de recuperación se reduce a la mitad.";
                case "fr":
                    return "La puissance de récupération est réduite de moitié.";
                case "de":
                    return "Die Erholungskraft wird auf 0,5 reduziert.";
                case "it":
                    return "Il potere di recupero si riduce a 0,5 volte.";
                case "pt":
                    return "O poder de recuperação é reduzido para 0,5 vezes.";
                case "ru":
                    return "Сила восстановления уменьшается в 2 раза.";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "攻撃力が1.5倍")
        {
            switch (langCode)
            {
                case "ja":
                    return "攻撃力が1.5倍";
                case "en":
                    return "Attack power is increased to 1.5 times.";
                case "zh-cn":
                    return "攻击力增加到1.5倍。";
                case "zh-tw":
                    return "攻擊力增加到1.5倍。";
                case "ko":
                    return "공격력이 1.5배로 증가합니다.";
                case "es":
                    return "El poder de ataque se incrementa a 1.5 veces.";
                case "fr":
                    return "La puissance d'attaque est augmentée à 1.5 fois.";
                case "de":
                    return "Die Angriffskraft wird um das 1,5-fache erhöht.";
                case "it":
                    return "La potenza d'attacco aumenta a 1,5 volte.";
                case "pt":
                    return "O poder de ataque aumenta para 1,5 vezes.";
                case "ru":
                    return "Сила атаки увеличивается в 1,5 раза.";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "回復力が1.5倍")
        {
            switch (langCode)
            {
                case "ja":
                    return "回復力が1.5倍";
                case "en":
                    return "Recovery power is increased to 1.5 times.";
                case "zh-cn":
                    return "恢复力增加到1.5倍。";
                case "zh-tw":
                    return "恢復力增加到1.5倍。";
                case "ko":
                    return "회복력이 1.5배로 증가합니다.";
                case "es":
                    return "El poder de recuperación se incrementa a 1.5 veces.";
                case "fr":
                    return "La puissance de récupération est augmentée à 1.5 fois.";
                case "de":
                    return "Die Erholungskraft wird um das 1,5-fache erhöht.";
                case "it":
                    return "La potenza di recupero aumenta a 1,5 volte.";
                case "pt":
                    return "O poder de recuperação aumenta para 1,5 vezes.";
                case "ru":
                    return "Сила восстановления увеличивается в 1,5 раза.";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "攻撃力が1.2倍")
        {
            switch (langCode)
            {
                case "ja":
                    return "攻撃力が1.2倍になる";
                case "en":
                    return "Attack power is increased to 1.2 times.";
                case "zh-cn":
                    return "攻击力增加到1.2倍。";
                case "zh-tw":
                    return "攻擊力增加到1.2倍。";
                case "ko":
                    return "공격력이 1.2배로 증가합니다.";
                case "es":
                    return "El poder de ataque se incrementa a 1.2 veces.";
                case "fr":
                    return "La puissance d'attaque est augmentée à 1.2 fois.";
                case "de":
                    return "Die Angriffskraft wird um das 1,2-fache erhöht.";
                case "it":
                    return "La potenza d'attacco aumenta a 1,2 volte.";
                case "pt":
                    return "O poder de ataque aumenta para 1,2 vezes.";
                case "ru":
                    return "Сила атаки увеличивается в 1,2 раза.";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "回復力が1.2倍")
        {
            switch (langCode)
            {
                case "ja":
                    return "回復力が1.2倍になる";
                case "en":
                    return "Recovery power is increased to 1.2 times.";
                case "zh-cn":
                    return "恢复力增加到1.2倍。";
                case "zh-tw":
                    return "恢復力增加到1.2倍。";
                case "ko":
                    return "회복력이 1.2배로 증가합니다.";
                case "es":
                    return "El poder de recuperación se incrementa a 1.2 veces.";
                case "fr":
                    return "La puissance de récupération est augmentée à 1.2 fois.";
                case "de":
                    return "Die Erholungskraft wird um das 1,2-fache erhöht.";
                case "it":
                    return "La potenza di recupero aumenta a 1,2 volte.";
                case "pt":
                    return "O poder de recuperação aumenta para 1,2 vezes.";
                case "ru":
                    return "Сила восстановления увеличивается в 1,2 раза.";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "敗北アドバイス")
        {
            switch (langCode)
            {
                case "ja":
                    return "ステージレベルを少し下げて良い装備品を獲得すると、攻略しやすくなるかも。";
                case "en":
                    return "Lowering the stage level slightly and obtaining good equipment may make it easier to conquer.";
                case "zh-cn":
                    return "略微降低关卡等级并获得良好的装备可能会使征服变得更容易。";
                case "zh-tw":
                    return "略微降低關卡等級並獲得優良的裝備可能會使征服變得更容易。";
                case "ko":
                    return "스테이지 레벨을 약간 낮추고 좋은 장비를 얻으면 정복하기가 더 쉬워질 수 있습니다.";
                case "es":
                    return "Bajar ligeramente el nivel de la etapa y obtener buen equipo puede hacer que sea más fácil conquistar.";
                case "fr":
                    return "Abaisser légèrement le niveau de la scène et obtenir un bon équipement peut rendre la conquête plus facile.";
                case "de":
                    return "Das Senken des Bühnenlevels und das Erlangen guter Ausrüstung kann die Eroberung erleichtern.";
                case "it":
                    return "Abbassando leggermente il livello della fase e ottenendo un buon equipaggiamento potrebbe rendere più facile la conquista.";
                case "pt":
                    return "Diminuir um pouco o nível da fase e obter equipamento bom pode facilitar a conquista.";
                case "ru":
                    return "Снижение уровня этапа и получение хорошей экипировки может облегчить завоевание.";
                default:
                    return "Translation not available";
            }
        }
        if (jaText == "")
        {
            switch (langCode)
            {
            }
        }

        return "";
    }

    // トップ画面のチュートリアル文章
    public List<string> GetFirstTopTutorialText()
    {
        List<string> text = new List<string>();
        string language = playerPrefsManager.GetLanguage();
        switch (language)
        {
            case "ja":
                text.Add("ここは全体マップ。各ステージに挑戦するにはここからステージを選んでプレイするよ。\r\n" +
                    "火山・船・森林の3つの通常ステージと、通常ステージをクリアすると出現するボスステージがあるよ。");
                text.Add("火山は火属性、船は水属性、森林は木属性の敵が出現し、火には水の、水には木の、木には火の攻撃をすると大きなダメージを与えられるよ。");
                text.Add("まずは3つのステージを1つずつクリアしてボスを出現させよう。\r\n" + "左下の街では装備品の確認や設定の変更ができるよ。");
                break;
            case "en":
                text.Add("This is the world map. To challenge each stage, select it from here and play. There are three regular stages: Volcano, Ship, and Forest, as well as boss stages that appear after clearing regular stages.");
                text.Add("Volcanoes have fire attributes, ships have water attributes, and forests have wood attributes for enemies. Dealing fire damage to water, water damage to wood, and wood damage to fire will inflict significant damage.");
                text.Add("Start by clearing each of the three stages one by one to summon the boss. In the lower-left town, you can check your equipment and make settings.");
                break;
            case "zh-cn":
                text.Add("这是世界地图。要挑战每个关卡，请从这里选择并开始游戏。有三个常规关卡：火山、船和森林，还有在通关常规关卡后出现的Boss关卡。");
                text.Add("火山具有火属性，船具有水属性，森林具有木属性的敌人。对水造成火属性伤害，对木造成水属性伤害，对火造成木属性伤害将会造成显著的伤害。");
                text.Add("从逐个清除三个阶段开始，以召唤Boss。在左下角的城镇，您可以检查您的装备并进行设置。");
                break;
            case "zh-tw":
                text.Add("這是世界地圖。要挑戰每個階段，請從這裡選擇並開始遊戲。有三個常規階段：火山、船和森林，還有在通過常規階段後出現的Boss階段。");
                text.Add("火山具有火屬性，船具有水屬性，森林具有木屬性的敵人。對水造成火屬性傷害，對木造成水屬性傷害，對火造成木屬性傷害將會造成顯著的傷害。");
                text.Add("從逐個清除三個階段開始，以召喚Boss。在左下角的城鎮，您可以檢查您的裝備並進行設置。");
                break;
            case "ko":
                text.Add("이곳은 월드 맵입니다. 각 스테이지에 도전하려면 여기에서 선택하고 플레이하십시오. 화산, 배, 숲이라는 세 개의 일반 스테이지와 정규 스테이지를 클리어하면 나타나는 보스 스테이지가 있습니다.");
                text.Add("화산은 화속성, 배는 물속성, 숲은 나무속성의 적이 나타납니다. 물에 화염 데미지, 나무에 물 데미지, 화에 나무 데미지를 입히면 상당한 데미지가 발생합니다.");
                text.Add("보스를 소환하려면 3개의 스테이지를 하나씩 클리어하세요. 왼쪽 아래의 마을에서 장비를 확인하고 설정을 변경할 수 있습니다.");
                break;
            case "es":
                text.Add("Este es el mapa del mundo. Para desafiar cada etapa, selecciónala desde aquí y juega. Hay tres etapas normales: Volcán, Barco y Bosque, además de las etapas de jefe que aparecen después de completar las etapas normales.");
                text.Add("Los volcanes tienen atributos de fuego, los barcos tienen atributos de agua y los bosques tienen atributos de madera para los enemigos. Infligir daño de fuego al agua, daño de agua a la madera y daño de madera al fuego causará un daño significativo.");
                text.Add("Comienza limpiando cada uno de los tres niveles uno por uno para invocar al jefe. En la ciudad de la esquina inferior izquierda, puedes verificar tu equipo y realizar ajustes.");
                break;
            case "fr":
                text.Add("Ceci est la carte du monde. Pour défier chaque étape, sélectionnez-la ici et jouez. Il y a trois étapes normales : Volcan, Bateau et Forêt, ainsi que des étapes de boss qui apparaissent après avoir terminé les étapes normales.");
                text.Add("Les volcans ont des attributs de feu, les navires ont des attributs d'eau, et les forêts ont des attributs de bois pour les ennemis. Infliger des dégâts de feu à l'eau, des dégâts d'eau au bois et des dégâts de bois au feu causera des dégâts importants.");
                text.Add("Commencez par effacer un par un les trois niveaux pour invoquer le boss. Dans la ville en bas à gauche, vous pouvez vérifier votre équipement et effectuer des réglages.");
                break;
            case "de":
                text.Add("Dies ist die Weltkarte. Um jede Stufe herauszufordern, wählen Sie sie hier aus und spielen Sie. Es gibt drei normale Stufen: Vulkan, Schiff und Wald, sowie Boss-Stufen, die nach dem Abschluss der normalen Stufen erscheinen.");
                text.Add("Vulkane haben Feuereigenschaften, Schiffe haben Wassereigenschaften und Wälder haben Holzeigenschaften für Feinde. Feuerschaden gegen Wasser, Wasserschaden gegen Holz und Holzschaden gegen Feuer verursachen erheblichen Schaden.");
                text.Add("Beginnen Sie damit, die drei Stufen nacheinander zu räumen, um den Boss herbeizurufen. In der Stadt unten links können Sie Ihre Ausrüstung überprüfen und Einstellungen vornehmen.");
                break;
            case "it":
                text.Add("Questa è la mappa del mondo. Per affrontare ogni stage, selezionalo da qui e gioca. Ci sono tre stage normali: Vulcano, Nave e Foresta, oltre alle stage del boss che appaiono dopo aver completato gli stage normali.");
                text.Add("I vulcani hanno attributi di fuoco, le navi hanno attributi d'acqua e le foreste hanno attributi di legno per i nemici. Infliggere danni da fuoco all'acqua, danni da acqua al legno e danni da legno al fuoco causerà danni significativi.");
                text.Add("Inizia cancellando uno per uno i tre livelli per evocare il boss. Nella città in basso a sinistra, puoi verificare la tua attrezzatura e apportare impostazioni.");
                break;
            case "pt":
                text.Add("Este é o mapa do mundo. Para desafiar cada fase, selecione-a daqui e jogue. Existem três fases normais: Vulcão, Navio e Floresta, além de fases de chefes que aparecem após a conclusão das fases normais.");
                text.Add("Os vulcões têm atributos de fogo, os navios têm atributos de água e as florestas têm atributos de madeira para os inimigos. Causar dano de fogo à água, dano de água à madeira e dano de madeira ao fogo infligirá um dano significativo.");
                text.Add("Comece limpando cada um dos três estágios um por um para invocar o chefe. Na cidade no canto inferior esquerdo, você pode verificar seu equipamento e fazer configurações.");
                break;
            case "ru":
                text.Add("Это карта мира. Для вызова каждого уровня выберите его здесь и играйте. Есть три обычных уровня: Вулкан, Корабль и Лес, а также босс-уровни, которые появляются после прохождения обычных уровней.");
                text.Add("Вулканы обладают атрибутами огня, корабли обладают атрибутами воды, а леса обладают атрибутами дерева для врагов. Нанесение огненного урона воде, водяного урона дереву и деревянного урона огню причинит значительный урон.");
                text.Add("Начните с очистки каждого из трех уровней поочередно, чтобы призвать босса. В нижнем левом городе вы можете проверить свое снаряжение и внести настройки.");
                break;
            default:
                
                break;
        }

        return text;
    }

    // ホーム画面のチュートリアル文章
    public List<string> GetFirstHomeTutorialText()
    {
        List<string> text = new List<string>();
        string language = playerPrefsManager.GetLanguage();
        switch (language)
        {
            case "ja":
                text.Add("装備品の確認ができるよ。上の2つは型（モールド）、下の2つはスキルだよ。\r\n" +
                    "それぞれの装備品にはHP・攻撃力・回復力があり、合計した値がプレイヤーの強さになるよ。");
                text.Add("もし特殊効果を持っている場合は、右側に表示されるよ。\r\n" +
                    "モールドには倍率が設定されていて、パズルをしたときの攻撃や回復の値に影響するよ。複雑なモールドであればあるほど高い倍率が設定されているみたいだ。");
                text.Add("スキルアイコンの右上にある数はスキルが発動可能となるターン数だよ。");
                break;
            case "en": // 英語
                text.Add("You can check your equipment. The top two are types, and the bottom two are skills. Each piece of equipment has HP, Attack Power, and Recovery Power, and the total value determines the player's strength.");
                text.Add("If you have special effects, they will be displayed on the right. Types have multipliers set, which affect the values of attacks and recovery when solving puzzles. It seems that more complex types have higher multipliers set.");
                text.Add("The number at the top right of the skill icon represents the number of turns until the skill can be activated.");
                break;
            case "zh-cn": // 簡体字
                text.Add("你可以检查你的装备。前两个是类型，下面两个是技能。每件装备都有生命值、攻击力和恢复力，总值决定了玩家的力量。");
                text.Add("如果你有特殊效果，它们将显示在右边。类型具有设置的倍增器，影响解决拼图时的攻击和恢复值。似乎更复杂的类型设置了更高的倍增器。");
                text.Add("技能图标右上角的数字表示技能激活所需的回合数。");
                break;
            case "zh-tw": // 繁体字
                text.Add("你可以檢查你的裝備。上面兩個是型，下面兩個是技能。每件裝備都有生命值、攻擊力和恢復力，總值決定了玩家的強度。");

                text.Add("如果你有特殊效果，它們將顯示在右邊。型具有設置的倍增器，影響解決拼圖時的攻擊和恢復值。似乎越複雜的型設置了更高的倍增器。");

                text.Add("技能圖標右上角的數字表示技能啟動所需的回合數。");
                break;
            case "ko": // 韓国語
                text.Add("장비를 확인할 수 있어요. 위의 두 개는 유형이고, 아래의 두 개는 기술이에요. 각 장비에는 체력, 공격력, 회복력이 있으며, 총 값이 플레이어의 강도를 결정해요.");

                text.Add("특수 효과가 있는 경우 오른쪽에 표시됩니다. 유형에는 설정된 배율이 있어 퍼즐을 풀 때 공격 및 회복 값에 영향을 미치며, 더 복잡한 유형일수록 더 높은 배율이 설정된 것 같아요.");

                text.Add("스킬 아이콘 오른쪽 위에 있는 숫자는 스킬을 발동할 수 있는 턴 수를 나타냅니다.");
                break;
            case "es": // スペイン語
                text.Add("Puedes verificar tu equipo. Los dos de arriba son tipos, y los dos de abajo son habilidades. Cada pieza de equipo tiene puntos de vida, potencia de ataque y poder de recuperación, y el valor total determina la fuerza del jugador.");

                text.Add("Si tienes efectos especiales, se mostrarán a la derecha. Los tipos tienen multiplicadores configurados que afectan los valores de los ataques y la recuperación al resolver los rompecabezas. Parece que los tipos más complejos tienen multiplicadores más altos configurados.");

                text.Add("El número en la parte superior derecha del icono de habilidad representa la cantidad de turnos restantes hasta que la habilidad se pueda activar.");
                break;
            case "fr": // フランス語
                text.Add("Vous pouvez vérifier votre équipement. Les deux du haut sont des types, et les deux du bas sont des compétences. Chaque pièce d'équipement a des points de vie, une puissance d'attaque et un pouvoir de récupération, et la valeur totale détermine la force du joueur.");

                text.Add("Si vous avez des effets spéciaux, ils s'afficheront à droite. Les types ont des multiplicateurs configurés qui affectent les valeurs des attaques et de la récupération lors de la résolution des puzzles. Il semble que les types plus complexes aient des multiplicateurs plus élevés configurés.");

                text.Add("Le nombre en haut à droite de l'icône de compétence représente le nombre de tours restants avant que la compétence puisse être activée.");
                break;
            case "de": // ドイツ語
                text.Add("Du kannst deine Ausrüstung überprüfen. Die beiden oberen sind Typen und die beiden unteren sind Fähigkeiten. Jede Ausrüstung hat Lebenspunkte, Angriffskraft und Erholungskraft, und der Gesamtwert bestimmt die Stärke des Spielers.");

                text.Add("Wenn du spezielle Effekte hast, werden sie rechts angezeigt. Typen haben festgelegte Multiplikatoren, die die Werte von Angriffen und Heilung bei der Lösung von Rätseln beeinflussen. Es scheint, dass komplexere Typen höhere Multiplikatoren haben.");

                text.Add("Die Zahl oben rechts neben dem Fähigkeits-Icon zeigt an, wie viele Runden noch verbleiben, bis die Fähigkeit aktiviert werden kann.");
                break;
            case "it": // イタリア語
                text.Add("Puoi controllare il tuo equipaggiamento. I primi due sono tipi e gli ultimi due sono abilità. Ogni pezzo di equipaggiamento ha punti ferita, potenza d'attacco e potere di recupero, e il valore totale determina la forza del giocatore.");

                text.Add("Se hai effetti speciali, verranno mostrati a destra. I tipi hanno moltiplicatori configurati che influenzano i valori degli attacchi e della guarigione durante la risoluzione dei puzzle. Sembra che i tipi più complessi abbiano moltiplicatori più alti configurati.");

                text.Add("Il numero in alto a destra dell'icona delle abilità rappresenta il numero di turni rimanenti prima che l'abilità possa essere attivata.");
                break;
            case "pt": // ポルトガル語
                text.Add("Você pode verificar seu equipamento. Os dois superiores são tipos e os dois inferiores são habilidades. Cada peça de equipamento possui pontos de vida, potência de ataque e poder de recuperação, e o valor total determina a força do jogador.");

                text.Add("Se você tiver efeitos especiais, eles serão exibidos à direita. Os tipos têm multiplicadores configurados que afetam os valores dos ataques e da recuperação ao resolver quebra-cabeças. Parece que tipos mais complexos têm multiplicadores mais altos configurados.");

                text.Add("O número no canto superior direito do ícone de habilidade representa o número de turnos restantes até que a habilidade possa ser ativada.");
                break;
            case "ru": // ロシア語
                text.Add("Вы можете проверить свою экипировку. Верхние два - это типы, а нижние два - навыки. У каждой части снаряжения есть очки здоровья, сила атаки и способность восстановления, и общая стоимость определяет силу игрока.");

                text.Add("Если у вас есть специальные эффекты, они будут отображаться справа. У типов есть установленные множители, которые влияют на значения атак и восстановления при решении головоломок. Кажется, что у более сложных типов установлены более высокие множители.");

                text.Add("Число в верхнем правом углу иконки навыка представляет собой количество оставшихся ходов, пока навык не сможет быть активирован.");
                break;
            default:
                break;
        }

        return text;
    }

    // パズル出現画面のチュートリアル文章
    public List<string> GetFirstPuzzleTutorialText()
    {
        List<string> text = new List<string>();
        string language = playerPrefsManager.GetLanguage();
        switch (language)
        {
            case "ja": // 日本語
                text.Add("初めてのパズルだね。画面上部には敵の姿とHPバーが表示されているよ。敵のHPを0にしたら勝ち。\r\n" +
                    "画面下部に表示されているプレイヤーのHPが0になったら負けだよ。");
                text.Add("右下の型（モールド）は装備しているものが2つとステージ毎にランダムで生成されるものが1つ表示されていて\r\n" +
                    "真ん中にたくさんあるパネルをモールドのどれかの形にすることでパネルを消して敵に攻撃することができるよ。");
                text.Add("パネルはタップすると回転させることができるから、同じ色のパネルをモールドの形にうまく合わせてどんどん消していこう。");
                text.Add("パネルの色は攻撃する属性に対応していて、赤いパネルを消した場合は火属性の攻撃をするんだ。\r\n"+
                    "ピンクのパネルを消すとプレイヤーのHPを回復するよ。");
                text.Add("たまに白いパネルが現れるんだけど、それはどの色としても扱えるオールマイティなパネルだよ。\r\n" + "大量消去のチャンスだ！");
                text.Add("パネルを回転させて形を合わせ、真ん中のAttackボタンを押して攻撃。\r\n" + "その後に敵が攻撃をしてくる。これがターンの流れだよ。");
                text.Add("左下にはスキルボタンが2つ表示されているよ。スキルターンが0になって発動可能になったらボタンを押してスキルを発動しよう。");
                text.Add("Infoボタンを押すとプレイヤーの情報を確認できるよ。\r\n" + "モールドの下の数値は倍率だ。攻撃や回復の値に加算される。");
                text.Add("複雑なモールドであればあるほど倍率が高いので、積極的に多くのパネルを繋いでいって高倍率を狙っていこう。");
                break;
            case "en": // 英語
                text.Add("This is your first puzzle. At the top of the screen, you can see the enemy's appearance and HP bar. You win when you reduce the enemy's HP to 0. If your player's HP at the bottom of the screen reaches 0, you lose.");

                text.Add("In the bottom right, there are two equipped shapes and one randomly generated shape for each stage displayed. You can clear panels and attack enemies by matching a set of panels in the center to any of the shapes. The panels can be rotated by tapping them.");

                text.Add("Since you can rotate the panels, try to match panels of the same color to the mold's shape and clear them efficiently. Panel colors correspond to attack attributes; clearing red panels results in fire attribute attacks, and pink panels heal the player's HP.");

                text.Add("Occasionally, white panels appear, and they can be treated as any color—an all-purpose panel. It's a chance for massive clears!");

                text.Add("Rotate the panels to match the shape, then press the Attack button in the center. After that, the enemy will launch an attack. This is the flow of turns.");

                text.Add("Two skill buttons are displayed at the bottom left. When the skill turns reach 0, press the buttons to activate skills.");

                text.Add("Press the Info button to check player information. The numbers below the shapes represent multipliers, which are added to attack and recovery values.");

                text.Add("The more complex the mold, the higher the multiplier, so actively connect as many panels as possible to aim for a high multiplier.");
                break;
            case "zh-cn": // 簡体字
                text.Add("这是你的第一个拼图。在屏幕顶部，你可以看到敌人的外貌和血量条。当你将敌人的血量减少到零时，你获胜。如果屏幕底部显示的玩家血量达到零，你就输了。");

                text.Add("右下角有两个已装备的形状和每个阶段随机生成的一个形状。你可以通过将中间的面板与任何形状匹配来清除面板并攻击敌人。面板可以通过点击旋转。");

                text.Add("由于你可以旋转面板，尝试将相同颜色的面板与模板的形状匹配，以高效地清除它们。面板的颜色对应攻击属性；清除红色面板会导致火属性攻击，而粉色面板会恢复玩家的血量。");

                text.Add("偶尔会出现白色面板，它们可以视为任何颜色 - 一种多用途的面板。这是大规模清除的机会！");

                text.Add("旋转面板以匹配形状，然后按中间的攻击按钮。之后，敌人将发动攻击。这就是回合的流程。");

                text.Add("左下角显示了两个技能按钮。当技能回合达到0时，按下按钮以激活技能。");

                text.Add("按下信息按钮以查看玩家信息。形状下方的数字代表倍增器，将添加到攻击和恢复值。");

                text.Add("模板越复杂，倍增器越高，因此积极连接尽可能多的面板，以获得更高的倍增器。");
                break;
            case "zh-tw": // 繁体字
                text.Add("這是你的第一個拼圖。在屏幕頂部，你可以看到敵人的外貌和血量條。當你將敵人的血量減少到零時，你獲勝。如果屏幕底部顯示的玩家血量達到零，你就輸了。");

                text.Add("右下角有兩個已裝備的形狀和每個階段隨機生成的一個形狀。你可以通過將中間的面板與任何形狀匹配來清除面板並攻擊敵人。面板可以通過點擊旋轉。");

                text.Add("由於你可以旋轉面板，嘗試將相同顏色的面板與模板的形狀匹配，以高效地清除它們。面板的顏色對應攻擊屬性；清除紅色面板會導致火屬性攻擊，而粉色面板會恢復玩家的血量。");

                text.Add("偶爾會出現白色面板，它們可以視為任何顏色 - 一種多用途的面板。這是大規模清除的機會！");

                text.Add("旋轉面板以匹配形狀，然後按中間的攻擊按鈕。之後，敵人將發動攻擊。這就是回合的流程。");

                text.Add("左下角顯示了兩個技能按鈕。當技能回合達到0時，按下按鈕以啟動技能。");

                text.Add("按下信息按鈕以查看玩家信息。形狀下方的數字代表倍增器，將添加到攻擊和恢復值。");

                text.Add("模板越複雜，倍增器越高，因此積極連接尽可能多的面板，以獲得更高的倍增器。");
                break;
            case "ko": // 韓国語
                text.Add("이것은 당신의 첫 퍼즐입니다. 화면 상단에는 적의 모습과 HP 바가 표시됩니다. 적의 HP를 0으로 낮추면 이기게 됩니다. 화면 하단에 표시된 플레이어의 HP가 0이되면 패배합니다.");

                text.Add("오른쪽 하단에는 두 가지 장착된 형태와 각 스테이지마다 무작위로 생성되는 하나의 형태가 표시됩니다. 중앙의 패널 중 하나의 형태로 일치시켜 패널을 제거하고 적을 공격할 수 있습니다. 패널은 탭하여 회전시킬 수 있습니다.");

                text.Add("패널을 회전시킬 수 있으므로 동일한 색의 패널을 모양에 맞추어 효율적으로 제거해보세요. 패널 색상은 공격 속성에 해당하며, 빨간 패널을 제거하면 불 속성 공격이 발동되고 분홍색 패널을 제거하면 플레이어의 HP가 회복됩니다.");

                text.Add("가끔하면 하얀 패널이 나타납니다. 이것은 모든 색상으로 처리할 수 있는 만능 패널입니다. 대규모 제거의 기회입니다!");

                text.Add("패널을 회전하여 모양을 일치시킨 다음 중앙의 '공격' 버튼을 누르세요. 그 후에 적이 공격을 시작합니다. 이것이 턴의 흐름입니다.");

                text.Add("왼쪽 아래에는 두 개의 스킬 버튼이 표시됩니다. 스킬 턴이 0이되면 버튼을 눌러 스킬을 활성화하세요.");

                text.Add("정보 버튼을 누르면 플레이어 정보를 확인할 수 있습니다. 모양 아래의 숫자는 배율을 나타내며, 공격 및 회복 값에 추가됩니다.");

                text.Add("모양이 더 복잡할수록 배율이 높아지므로 최대한 많은 패널을 연결하여 높은 배율을 목표로 하세요.");
                break;
            case "es": // スペイン語
                text.Add("Este es tu primer rompecabezas. En la parte superior de la pantalla, puedes ver la apariencia del enemigo y la barra de HP. Ganas cuando reduces la HP del enemigo a 0. Si la HP del jugador en la parte inferior de la pantalla llega a 0, pierdes.");

                text.Add("En la esquina inferior derecha, hay dos formas equipadas y una forma generada al azar para cada etapa que se muestra. Puedes limpiar paneles y atacar a los enemigos haciendo coincidir un conjunto de paneles en el centro con cualquiera de las formas. Los paneles se pueden girar tocándolos.");

                text.Add("Dado que puedes girar los paneles, intenta hacer coincidir los paneles del mismo color con la forma del molde y límpialos de manera eficiente. Los colores de los paneles corresponden a los atributos de ataque; al limpiar paneles rojos, se producen ataques de atributo de fuego, y los paneles rosados ​​restauran la HP del jugador.");

                text.Add("Ocasionalmente, aparecen paneles blancos, y pueden tratarse como cualquier color, ¡un panel todopoderoso! ¡Es una oportunidad para eliminar en masa!");

                text.Add("Gira los paneles para que coincidan con la forma y luego presiona el botón de Ataque en el centro. Después de eso, el enemigo lanzará un ataque. Este es el flujo de los turnos.");

                text.Add("Se muestran dos botones de habilidad en la esquina inferior izquierda. Cuando los turnos de habilidad lleguen a 0, presiona los botones para activar las habilidades.");

                text.Add("Presiona el botón de Información para verificar la información del jugador. Los números debajo de las formas representan multiplicadores, que se suman a los valores de ataque y recuperación.");

                text.Add("Cuanto más complejo sea el molde, mayor será el multiplicador, así que conecta activamente tantos paneles como sea posible para apuntar a un multiplicador alto.");
                break;
            case "fr": // フランス語
                text.Add("Ceci est votre premier puzzle. En haut de l'écran, vous pouvez voir l'apparence de l'ennemi et la barre de points de vie (HP). Vous gagnez lorsque vous réduisez les HP de l'ennemi à zéro. Si les HP de votre joueur en bas de l'écran atteignent zéro, vous perdez.");

                text.Add("En bas à droite, vous avez deux formes équipées et une forme générée aléatoirement pour chaque étape affichée. Vous pouvez nettoyer des panneaux et attaquer des ennemis en faisant correspondre un ensemble de panneaux au centre avec l'une des formes. Les panneaux peuvent être tournés en les tapant.");

                text.Add("Comme vous pouvez faire tourner les panneaux, essayez de faire correspondre des panneaux de la même couleur avec la forme du moule et nettoyez-les de manière efficace. Les couleurs des panneaux correspondent aux attributs d'attaque ; en nettoyant les panneaux rouges, des attaques de l'attribut feu sont déclenchées, et les panneaux roses restaurent les HP du joueur.");

                text.Add("De temps en temps, des panneaux blancs apparaissent, et ils peuvent être traités comme n'importe quelle couleur, un panneau polyvalent ! C'est une chance pour un nettoyage massif !");

                text.Add("Tournez les panneaux pour les faire correspondre à la forme, puis appuyez sur le bouton Attaque au centre. Ensuite, l'ennemi lancera une attaque. C'est le déroulement des tours.");

                text.Add("Deux boutons de compétence sont affichés en bas à gauche. Lorsque les tours de compétence atteignent zéro, appuyez sur les boutons pour activer les compétences.");

                text.Add("Appuyez sur le bouton Info pour vérifier les informations du joueur. Les chiffres sous les formes représentent des multiplicateurs, qui sont ajoutés aux valeurs d'attaque et de récupération.");

                text.Add("Plus la forme est complexe, plus le multiplicateur est élevé, alors connectez activement autant de panneaux que possible pour viser un multiplicateur élevé.");
                break;
            case "de": // ドイツ語
                text.Add("Dies ist dein erstes Puzzle. Am oberen Bildschirmrand kannst du das Aussehen des Feindes und die HP-Leiste sehen. Du gewinnst, wenn du die HP des Feindes auf 0 reduzierst. Wenn die HP deines Spielers unten auf dem Bildschirm 0 erreichen, verlierst du.");

                text.Add("Unten rechts siehst du zwei ausgerüstete Formen und eine zufällig generierte Form für jede Stufe. Du kannst Panel löschen und Feinde angreifen, indem du einen Satz von Paneln in der Mitte mit einer der Formen abgleichst. Die Panel können durch Antippen gedreht werden.");

                text.Add("Da du die Panel drehen kannst, versuche, Panel der gleichen Farbe mit der Form des Modells effizient zu kombinieren und zu löschen. Die Farben der Panel entsprechen den Angriffsattributen; das Löschen von roten Paneln führt zu Feuerattribut-Angriffen, und rosa Paneln stellen die HP des Spielers wieder her.");

                text.Add("Gelegentlich erscheinen weiße Panel, und sie können als jede Farbe behandelt werden - ein vielseitiges Panel! Es ist eine Chance für Massenlöschungen!");

                text.Add("Drehe die Panel, um sie an die Form anzupassen, und drücke dann die Angriffstaste in der Mitte. Danach wird der Feind einen Angriff starten. Das ist der Ablauf der Runden.");

                text.Add("Unten links werden zwei Fähigkeitsknöpfe angezeigt. Wenn die Fähigkeitsrunden auf 0 fallen, drücke die Knöpfe, um die Fähigkeiten zu aktivieren.");

                text.Add("Drücke die Info-Taste, um Spielerinformationen zu überprüfen. Die Zahlen unter den Formen stellen Multiplikatoren dar, die zu Angriffs- und Wiederherstellungswerten hinzugefügt werden.");

                text.Add("Je komplexer die Form, desto höher der Multiplikator, also verbinde aktiv so viele Panel wie möglich, um auf einen hohen Multiplikator abzuzielen.");
                break;
            case "it": // イタリア語
                text.Add("Questo è il tuo primo rompicapo. In alto dello schermo, puoi vedere l'aspetto del nemico e la barra HP. Vinci quando riduci l'HP del nemico a 0. Se l'HP del tuo giocatore in basso dello schermo raggiunge lo 0, perdi.");

                text.Add("In basso a destra, ci sono due forme equipaggiate e una forma generata casualmente per ogni livello visualizzato. Puoi cancellare i pannelli e attaccare i nemici abbinando un set di pannelli al centro con una delle forme. I pannelli possono essere ruotati toccandoli.");

                text.Add("Poiché puoi ruotare i pannelli, cerca di abbinare i pannelli dello stesso colore alla forma del modello e cancellali in modo efficiente. I colori dei pannelli corrispondono agli attributi di attacco; cancellando i pannelli rossi si scatenano attacchi di attributo fuoco, mentre i pannelli rosa ripristinano l'HP del giocatore.");

                text.Add("Di tanto in tanto, compaiono pannelli bianchi e possono essere trattati come qualsiasi colore, un pannello tuttofare! È un'opportunità per eliminare in massa!");

                text.Add("Ruota i pannelli per abbinarli alla forma, quindi premi il pulsante Attacco al centro. Dopo di ciò, il nemico lancerà un attacco. Questo è il flusso dei turni.");

                text.Add("In basso a sinistra sono visualizzati due pulsanti abilità. Quando i turni abilità raggiungono lo 0, premi i pulsanti per attivare le abilità.");

                text.Add("Premi il pulsante Info per verificare le informazioni del giocatore. I numeri sotto le forme rappresentano moltiplicatori, che vengono aggiunti ai valori di attacco e recupero.");

                text.Add("Più complessa è la forma, più alto è il moltiplicatore, quindi collega attivamente il maggior numero possibile di pannelli per mirare a un alto moltiplicatore.");
                break;
            case "pt": // ポルトガル語
                text.Add("Este é o seu primeiro quebra-cabeça. Na parte superior da tela, você pode ver a aparência do inimigo e a barra de HP. Você vence quando reduz os HP do inimigo a 0. Se os HP do jogador na parte inferior da tela chegarem a 0, você perde.");

                text.Add("No canto inferior direito, há duas formas equipadas e uma forma gerada aleatoriamente para cada fase exibida. Você pode limpar os painéis e atacar os inimigos combinando um conjunto de painéis no centro com uma das formas. Os painéis podem ser girados tocando neles.");

                text.Add("Como você pode girar os painéis, tente combinar os painéis da mesma cor com a forma do molde e limpá-los de forma eficiente. As cores dos painéis correspondem aos atributos de ataque; limpar painéis vermelhos desencadeia ataques do atributo fogo, enquanto painéis rosa restauram o HP do jogador.");

                text.Add("De vez em quando, aparecem painéis brancos, e eles podem ser tratados como qualquer cor - um painel versátil! É uma oportunidade para limpeza em massa!");

                text.Add("Gire os painéis para combiná-los com a forma e, em seguida, pressione o botão de Ataque no centro. Depois disso, o inimigo lançará um ataque. Este é o fluxo de turnos.");

                text.Add("Na parte inferior esquerda, são exibidos dois botões de habilidade. Quando os turnos de habilidade atingirem 0, pressione os botões para ativar as habilidades.");

                text.Add("Pressione o botão de Informações para verificar as informações do jogador. Os números sob as formas representam multiplicadores, que são adicionados aos valores de ataque e recuperação.");

                text.Add("Quanto mais complexa a forma, maior o multiplicador, então conecte ativamente o maior número possível de painéis para mirar um multiplicador alto.");
                break;
            case "ru": // ロシア語
                text.Add("Это ваша первая головоломка. В верхней части экрана вы можете увидеть внешность врага и полосу HP. Вы выигрываете, когда снижаете HP врага до нуля. Если HP вашего игрока внизу экрана достигает нуля, вы проигрываете.");

                text.Add("В правом нижнем углу есть две формы, которые уже экипированы, и одна форма, генерируемая случайным образом для каждого уровня. Вы можете очищать панели и атаковать врагов, сочетая набор панелей в центре с одной из форм. Панели можно поворачивать, касаясь их.");

                text.Add("Поскольку вы можете вращать панели, попробуйте эффективно сочетать панели одного цвета с формой матрицы и очищать их. Цвета панелей соответствуют атрибутам атаки; очищение красных панелей вызывает атаки атрибутом огня, а розовые панели восстанавливают HP игрока.");

                text.Add("Время от времени появляются белые панели, и их можно рассматривать как любой цвет - универсальная панель! Это шанс для массовой очистки!");

                text.Add("Вращайте панели, чтобы они соответствовали форме, а затем нажмите кнопку Атака в центре. После этого враг запустит атаку. Вот и происходит смена ходов.");

                text.Add("В левом нижнем углу отображаются две кнопки навыков. Когда ходы навыков достигают 0, нажмите кнопки, чтобы активировать навыки.");

                text.Add("Нажмите кнопку Информация, чтобы проверить информацию о игроке. Числа под формами представляют собой множители, которые добавляются к значениям атаки и восстановления.");

                text.Add("Чем сложнее форма, тем выше множитель, поэтому активно соединяйте как можно больше панелей, чтобы прицелиться на высокий множитель.");
                break;
            default:
                break;
        }

        return text;
    }

    // 勝利画面のチュートリアル文章
    public List<string> GetFirstWinTutorialText()
    {
        List<string> text = new List<string>();
        string language = playerPrefsManager.GetLanguage();
        switch (language)
        {
            case "ja":
                text.Add("おめでとう！記念すべき初勝利だね。\r\n" +
                    "敵に勝つとモールドかスキルのどちらか1つを獲得できるんだ。宝箱をタップして中身を確認しよう。");
                text.Add("気に入ったものが出たら装備しているものと交換しよう。交換した装備品は無くなってしまうので注意してね。\r\n" +
                    "あと動画広告を見ることで一定時間宝箱を2つにすることができるみたいだよ。");
                break;
            case "en":
                text.Add("Congratulations! It's your first victory. When you defeat an enemy, you can acquire either a Mould or a Skill. Tap the chest to check its contents.");
                text.Add("If you find something you like, try equipping it in exchange for what you are currently using. Be careful, as the exchanged equipment will be lost. Also, it seems you can double the number of chests for a certain period by watching a video ad.");
                break;
            case "zh-cn":
                text.Add("恭喜你！这是你的首次胜利。当你击败敌人时，你可以获得模具或技能中的一个。点击宝箱查看其内容。");
                text.Add("如果你找到了喜欢的东西，可以尝试装备它，以换取你目前正在使用的东西。要小心，因为交换的装备将会丢失。此外，通过观看视频广告，你似乎可以在一段时间内将宝箱数量翻倍。");
                break;
            case "zh-tw":
                text.Add("恭喜你！這是你的首次勝利。當你擊敗敵人時，你可以獲得模具或技能中的一個。點擊寶箱查看其內容。");
                text.Add("");
                break;
            case "ko":
                text.Add("축하합니다! 당신의 첫 승리입니다. 적을 이기면 몰드 또는 스킬 중 하나를 획득할 수 있습니다. 상자를 탭하여 내용을 확인하세요.");
                text.Add("마음에 드는 것을 찾았다면 현재 사용 중인 것과 교체하여 장착해보세요. 교환된 장비는 사라지게 되니 주의하세요. 또한 동영상 광고를 시청하여 일정 시간 동안 상자 수를 2배로 늘릴 수 있을 것 같습니다.\r\n");
                break;
            case "es":
                text.Add("¡Felicidades! Es tu primera victoria. Cuando derrotas a un enemigo, puedes obtener un Molde o una Habilidad. Toca el cofre para comprobar su contenido.");
                text.Add("Si encuentras algo que te gusta, intenta equiparlo a cambio de lo que estás usando actualmente. Ten cuidado, ya que el equipo intercambiado se perderá. Además, parece que puedes duplicar la cantidad de cofres por un período determinado viendo un anuncio de video.");
                break;
            case "fr":
                text.Add("Félicitations ! C'est ta première victoire. Lorsque tu bats un ennemi, tu peux obtenir soit un Moule, soit une Compétence. Touche le coffre pour vérifier son contenu.");
                text.Add("Si vous trouvez quelque chose que vous aimez, essayez de l'équiper en échange de ce que vous utilisez actuellement. Faites attention, car l'équipement échangé sera perdu. De plus, il semble que vous puissiez doubler le nombre de coffres pendant une période déterminée en regardant une publicité vidéo.");
                break;
            case "de":
                text.Add("Herzlichen Glückwunsch! Das ist dein erster Sieg. Wenn du einen Feind besiegst, kannst du entweder eine Form oder eine Fähigkeit erhalten. Tippe auf die Truhe, um ihren Inhalt zu überprüfen.");
                text.Add("Wenn du etwas findest, das dir gefällt, versuche es gegen das auszurüsten, was du derzeit benutzt. Sei vorsichtig, da die ausgetauschte Ausrüstung verloren geht. Außerdem scheint es, dass du die Anzahl der Truhen für einen bestimmten Zeitraum verdoppeln kannst, indem du dir ein Video ansiehst.");
                break;
            case "it":
                text.Add("Congratulazioni! È la tua prima vittoria. Quando sconfiggi un nemico, puoi ottenere uno Stampo o una Abilità. Tocca il baule per controllare il suo contenuto.");
                text.Add("Se trovi qualcosa che ti piace, prova ad equipaggiarlo in cambio di ciò che stai usando attualmente. Attenzione, poiché l'equipaggiamento scambiato verrà perso. Inoltre, sembra che tu possa raddoppiare il numero di casse per un certo periodo guardando un annuncio video.");
                break;
            case "pt":
                text.Add("Parabéns! É a tua primeira vitória. Quando derrotas um inimigo, podes adquirir um Molde ou uma Habilidade. Toca no baú para verificar o seu conteúdo.");
                text.Add("Se encontrar algo que goste, tente equipá-lo em troca do que está a usar atualmente. Tenha cuidado, pois o equipamento trocado será perdido. Além disso, parece que pode duplicar o número de baús por um período determinado ao ver um anúncio de vídeo.");
                break;
            case "ru":
                text.Add("Поздравляю! Это ваша первая победа. Когда вы побеждаете врага, вы можете получить либо Модель, либо Навык. Нажмите на сундук, чтобы проверить его содержимое.");
                text.Add("Если вам понравилась какая-то вещь, попробуйте экипировать ее взамен того, что вы используете в данный момент. Будьте осторожны, так как обменянное снаряжение будет потеряно. Кроме того, кажется, вы можете удвоить количество сундуков на определенное время, посмотрев видеорекламу.");
                break;
            default:
                break;
        }

        return text;
    }

    // ボス出現画面のチュートリアル文章
    public List<string> GetFirstBossAppearTutorialText()
    {
        List<string> text = new List<string>();
        string language = playerPrefsManager.GetLanguage();
        switch (language)
        {
            case "ja":
                text.Add("見て！真ん中にお城のようなものが現れたよ。あそこにボスがいるんだ。\r\n" +
                    "ボスは通常の敵よりも少し手強いから気を付けてね。");
                text.Add("ボスを倒すと画面左上のプレイヤーレベルが上昇して、よりレベルの高いステージに挑戦することができるようになるよ。");
                break;
            case "en": // 英語
                text.Add("Look! Something like a castle has appeared in the middle. That's where the boss is. The boss is a bit tougher than regular enemies, so be careful.");
                text.Add("Defeating the boss will increase your player level in the top left corner of the screen, allowing you to challenge higher-level stages.");
                break;
            case "zh-cn": // 簡体字
                text.Add("看！中间出现了类似城堡的东西。那里有boss。boss比普通敌人要强一点，所以要小心。");
                text.Add("打败boss将提升屏幕左上角的玩家等级，使您能够挑战更高级别的关卡。");
                break;
            case "zh-tw": // 繁体字
                text.Add("看！中間出現了像城堡的東西。那裡有boss。boss比普通敵人要強一點，所以要小心。");
                text.Add("打敗boss將提升畫面左上角的玩家等級，使您能夠挑戰更高等級的關卡。");
                break;
            case "ko": // 韓国語
                text.Add("봐봐요! 가운데에 성 같은 것이 나타났어요. 거기에 보스가 있어요. 보스는 일반 적보다 조금 더 강력하니 조심하세요.");
                text.Add("보스를 물리치면 화면 왼쪽 위의 플레이어 레벨이 상승하며, 더 높은 레벨의 스테이지에 도전할 수 있게 될 거에요.");
                break;
            case "es": // スペイン語
                text.Add("Mira! Algo parecido a un castillo ha aparecido en el medio. Ahí es donde está el jefe. El jefe es un poco más difícil que los enemigos normales, así que ten cuidado.");
                text.Add("Derrotar al jefe aumentará tu nivel de jugador en la esquina superior izquierda de la pantalla, lo que te permitirá desafiar etapas de mayor nivel.");
                break;
            case "fr": // フランス語
                text.Add("Regarde ! Quelque chose ressemblant à un château est apparu au milieu. C'est là que se trouve le boss. Le boss est un peu plus coriace que les ennemis normaux, alors fais attention.");
                text.Add("Vaincre le boss augmentera ton niveau de joueur en haut à gauche de l'écran, ce qui te permettra de défier des étapes de niveau supérieur.");
                break;
            case "de": // ドイツ語
                text.Add("Schau mal! In der Mitte ist etwas wie ein Schloss aufgetaucht. Das ist, wo der Boss ist. Der Boss ist etwas stärker als normale Feinde, also sei vorsichtig.");
                text.Add("Durch das Besiegen des Bosses steigt dein Spielerlevel oben links auf dem Bildschirm, was es dir ermöglicht, höherstufige Stufen herauszufordern.");
                break;
            case "it": // イタリア語
                text.Add("Guarda! Qualcosa simile a un castello è apparso al centro. È lì che si trova il boss. Il boss è un po' più duro dei nemici normali, quindi fai attenzione.");
                text.Add("Sconfiggere il boss aumenterà il tuo livello di giocatore nell'angolo in alto a sinistra dello schermo, consentendoti di sfidare stage di livello superiore.");
                break;
            case "pt": // ポルトガル語
                text.Add("Olha! Algo parecido com um castelo apareceu no meio. É aí que está o chefe. O chefe é um pouco mais difícil do que os inimigos normais, então tenha cuidado.");
                text.Add("Derrotar o chefe aumentará seu nível de jogador no canto superior esquerdo da tela, permitindo que você desafie estágios de nível mais alto.");
                break;
            case "ru": // ロシア語
                text.Add("Смотри! Что-то вроде замка появилось посередине. Там находится босс. Босс немного сильнее обычных врагов, так что будь осторожен.");
                text.Add("Победа над боссом повысит уровень игрока в левом верхнем углу экрана, что позволит тебе сразиться с более высокоуровневыми этапами.");
                break;
            default:
                break;
        }

        return text;
    }

    public List<string> GetFirstBossPuzzleTutorialText()
    {
        List<string> text = new List<string>();
        string language = playerPrefsManager.GetLanguage();
        switch (language)
        {
            case "ja":
                text.Add("ボスは通常の敵とは違って特殊な攻撃をしてくるよ。\r\n" + "敵の横に表示されている数字が0になると攻撃してくるので、注意しよう！");
                break;
            case "en": // 英語
                text.Add("Boss has special attacks that differ from regular enemies. They will attack when the number displayed next to the enemy reaches 0, so be careful!");
                break;
            case "zh-cn": // 簡体字
                text.Add("Boss具有与普通敌人不同的特殊攻击。当敌人旁边显示的数字达到0时，它们会进行攻击，所以要小心！");
                break;
            case "zh-tw": // 繁体字
                text.Add("Boss具有與普通敵人不同的特殊攻擊。當敵人旁邊顯示的數字達到0時，它們會進行攻擊，所以要小心！");
                break;
            case "ko": // 韓国語
                text.Add("보스는 일반 적과 다른 특수한 공격을 가지고 있습니다. 적 옆에 표시된 숫자가 0이되면 공격하므로 주의하세요!");
                break;
            case "es": // スペイン語
                text.Add("Los jefes tienen ataques especiales que difieren de los enemigos regulares. Atacarán cuando el número que aparece al lado del enemigo llegue a 0, ¡así que ten cuidado!");
                break;
            case "fr": // フランス語
                text.Add("Les boss ont des attaques spéciales qui diffèrent des ennemis normaux. Ils attaqueront lorsque le nombre affiché à côté de l'ennemi atteindra 0, alors faites attention !");
                break;
            case "de": // ドイツ語
                text.Add("Bosse haben spezielle Angriffe, die sich von normalen Feinden unterscheiden. Sie werden angreifen, wenn die Zahl neben dem Feind 0 erreicht, also sei vorsichtig!");
                break;
            case "it": // イタリア語
                text.Add("I boss hanno attacchi speciali che differiscono dai nemici normali. Attaccheranno quando il numero visualizzato accanto al nemico raggiungerà 0, quindi fai attenzione!");
                break;
            case "pt": // ポルトガル語
                text.Add("Os chefes têm ataques especiais que diferem dos inimigos regulares. Eles atacarão quando o número exibido ao lado do inimigo atingir 0, então fique atento!");
                break;
            case "ru": // ロシア語
                text.Add("У боссов есть специальные атаки, отличающиеся от обычных врагов. Они будут атаковать, когда число, отображаемое рядом с врагом, достигнет 0, поэтому будьте осторожны!");
                break;
            default:
                break;
        }

        return text;
    }
}
