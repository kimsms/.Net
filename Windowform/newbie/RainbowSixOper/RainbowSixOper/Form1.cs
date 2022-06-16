using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowSixOper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("망치로 각종 벽(강화X)이나 도구를 부술 수 있다.","슬레지");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("전자 장비를 무력화 시키는 EMP 폭탄을 3개을 가진다. \r\n폭발 피해는 없다.", "대처");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("원거리에서 파괴 가능한 벽이나 바리케이드 등 부술 수 있는 표면에 쏘면 파괴탄이 박히고 잠시 후 터진다. \r\n탄약 수는 3발. 폭발물과 동일한 판정이여서 파괴 가능한 벽면이나 캐슬의 방탄 패널 뿐 아니라 철조망, 이동식 방패도 파괴할 수 있다. \r\n사람에게 박히면 터지지 않고 불발 처리된다.", "애쉬");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("벽면과 바닥에 설치할 수 있는 폭발물로 방어팀이 강화하여 일반적으로 뚫을 수 없는 강화벽마저 파괴할 수 있다. ", "써마이트");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("방어팀의 전자 도구 및 미라의 검은 거울을 파괴할 수 있으며 적에게 직접 사용해 1의 피해를 줄 수도 있다. \r\n일반 드론과 다르게 점프 할 수 없어서 이동식 방패나 높은 턱을 넘지 못한다.", "트위치");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("거대하게 확장시킬 수 있는 방패로 확장 시 전면부 전체를 가릴 만큼 넓어진다.", "몽타뉴");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("열화상 기능이 탑재되어 있는 확대 조준경으로 정조준 시 조준경 중앙의 감지 부위에 적이 들어오면 적의 모습이 노랗게 표시되고 연막을 투시할 수 있다.", "글라즈");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("원격으로 격발할 수 있는 접착식 확산탄으로 파괴 가능한 표면에 설치한 뒤 격발하면 표면에 구멍을 뚫고 반대편으로 다섯 발의 소형 유탄을 연속으로 발사해 순차적으로 폭파한다.", "퓨즈");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("방패에 달린 LED 전구를 동시에 발광시켜 전방에 강력한 섬광을 발하는 방패로, 섬광에 노출되면 잠시 동안 상대의 시야가 마비 된다. \r\n정조준 한 상태에서도 사용할 수 있다.", "블리츠");
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("팔에 장착된 모니터를 펼쳐 벽과 연막을 포함한 모든 장애물 너머로 최대 20 m 내의 적 전자 장비들의 위치와 형태를 감지할 수 있다.", "아이큐");
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            MessageBox.Show("폭파 시 짙은 황색의 독가스가 펼쳐지고 독가스에 노출되면 피해를 입으며, 마구 기침을 한다. ", "스모크");
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            MessageBox.Show("바닥에만 설치하여 배치할 수 있으며 설치된 재머는 주변에 방해 전파를 발산해 범위 내의 적이 사용하는 전자 장비를 무력화시킨다.", "뮤트");
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            MessageBox.Show("적군을 가리지 않고 탄환을 막을 수 있으며 방탄판에는 탄환에 파인 흔적만 나고 절대로 뚫리지 않는다. \r\n근접공격 12번으로 완전히 파괴할 수 있다", "캐슬");
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            MessageBox.Show("심장 박동 감지기로 최대 9 m 범위 안의 적들을 장애물에 관계 없이 탐지할 수 있다. \r\n적들이 탐지되면 삑 거리는 소리와 함께 동그라미로 표시되며, 가까울수록 동그라미와 소리가 더 커진다.", "펄스");
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("아군과 자신을 부상 상태에서 즉시 소생시킬 수 있고, 부상 상태가 아닐 경우에는 생명력을 40 회복 시킨다. \r\n이 합산이 100을 초과할 경우 최대 140까지 추가 체력을 부여할 수 있다. ", "닥");
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            MessageBox.Show("방어력이 약 15% 증가한다 \r\n또한 헤드샷과 근접 공격을 제외한 피해에 대해서 무조건 부상 상태로 만든다. ", "룩");
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("출입문과 창틀에 설치 가능한 레이저 감지 지뢰이다. \r\n설치된 곳의 레이저를 통과하는 적이 감지되면 즉시 폭발해 주위에 피해를 입힌다. \r\n변수가 없을 경우 두 번 당하면 다운된다.", "캅칸");
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("유탄 발사기로 \r\n유탄을 발사하고 바닥에 유탄이 떨어지면 카피탕의 불화살처럼 불이 퍼진다.", "타찬카");
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("벽이나 바닥에 설치할 수 있는 능동 방어 장치로 범위 내에 들어온 투사체를 요격하는 장비이다. \r\n각 ADS 한 개당 한번에 1개의 투사체를 무력화할 수 있고 한번 요격하면 10초를 기다려야 다시 요격할 수 있지만 요격 횟수는 무제한이다.", "예거");
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("금속제 장비에 연결할 수 있는 발전기로 \r\n고압선이 연결된 장비에 적이 접촉하면 감전 피해를 입으며 모든 설치식 전자 장비와 드론, 투척 무기 및 애쉬의 파괴탄은 접촉 시 바로 파괴된다. \r\n강화벽 하나당 하나의 고압선을 깔 수 있다.", "밴딧");
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            MessageBox.Show("부착식 산탄총의 특징은 다른 산탄총보다 압도적으로 뛰어난 지형 파괴력과 속도로, 단 한 발로 지나다닐 수 있는 통로를 만들 수 있을 정도로 높은 지형 파괴력과 200 RPM의 높은 연사력, 파지법만 바꾸면 되는 매우 빠른 무기 전환 속도를 가지고 있다.", "벅");
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            MessageBox.Show("소총에 부착할 수 있는 좌우로 넓은 모양의 방탄 방패 \r\n부착 시 장면에서 머리쪽으로 날아오는 총탄을 20 대미지까지 방어할 수 있다.", "블랙비어드");
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            MessageBox.Show("전술 석궁으로 일정 범위에 화염을 전개하는 폭발 화살과 연막을 전개할 수 있는 연막 화살을 각각 2개씩 사용하고 필요할 때 마다 수시로 교체해 사용할 수 있다.", "카피탕");
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            MessageBox.Show("파괴 가능한 벽과 강화벽을 파괴할 수 있는 발화성 유탄을 원거리에서 부착시키는 발사기 \r\n총 18발을 가지고 있으며 2개, 4개, 6개로 전환하며 사용할 수 있다.", "히바나");
        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            MessageBox.Show("바닥에 펼쳐서 설치하는 직사각형 모양의 기계식 덫이다. \r\n마치 곰덫처럼 적이 덫을 밟는 즉시 전술 함정의 이가 적의 다리를 물어서 적을 부상 상태로 쓰러뜨리며, 전술 함정에 의해 부상 상태에 빠진 적은 일반적인 부상 상태와는 달리 지혈하거나 기어서 이동할 수 없다.", "프로스트");
        }

        private void pictureBox39_Click(object sender, EventArgs e)
        {
            MessageBox.Show("던져서 부착 가능한 감시 카메라로 모든 아군이 사용할 수 있으며 화면이 푸른 색이고 일반 CCTV보다 시야각이 넓다. \r\n사용 시 구체 중앙에 푸른 원이 켜진다.", "발키리");
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            MessageBox.Show("잠행 능력 사용 시에는 살금살금 걷는 듯한 동작을 취하며 발소리가 작아지고, 무장이 권총으로 강제 전환된다. \r\n또한 잠행을 사용한 상태에서 서 있으면 평상시보다 에임이 살짝 아래로 내려가게 된다. 뛰거나 걸으면 여전히 소리가 작게라도 나지만, 앉아서 이동하면 소리가 거의 나지 않는다.", "카베이라");
        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            MessageBox.Show("일반적인 드론처럼 점프를 할 수는 없지만 공중으로 떠올라 위에 있는 천장이나 물체에 붙을 수 있다. \r\n천장에 부착된 상태에서는 적에게 음파를 발사할 수 있다. \r\n음파에 맞으면 잡음과 이명이 들리면서 청각이 차단되고 화면이 흐려지며 이 현상은 10초 지속된다. \r\n폭탄 해체기 설치 중에 음파를 맞으면 설치가 취소되어 남은 시간이 0이라면 승리하게 된다.", "에코");
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            MessageBox.Show("발자국을 탐지 및 추적할 수 있는 고글로, 활성화하면 화면 색상이 청보랏빛으로 바뀌고 방어팀이 지나간 자리에 발자국이 드러난다. \r\n발자국은 총 4가지 종류로 나뉘고 각 대원마다 다른 발자국이 배정되어있다. 각 색상의 시간은 다음과 같다. \r\n[빨간색] : ~15초 \r\n[노란색] : 15~30초 \r\n[초록색] : 30~60초 \r\n[파란색] : 60~90초", "자칼");
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            MessageBox.Show("던지거나, 굴리거나, 벽 또는 바닥에 부착해 사용할 수 있는 섬광 집속탄(칸델라)으로 터지면 내부에서 7발의 섬광 자탄이 주변에 뿌려진다. \r\n칸델라를 굴리면 칸델라가 굴러가는 모습이 윤곽선으로 잉에게만 보이며 칸델라는 물체에 부딪친 후 빠르게 터지는 기존 섬광탄과 달리 무조건 바닥에만 닿아야 격발되고, 버튼을 홀드하여 칸델라를 계속 들면 3초에서 1초까지 격발의 지연 시간을 단축할 수 있다.", "잉");
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            MessageBox.Show("더블 배럴 유탄 발사기로 진탕탄 2발과 충격탄 2발, 총 4발의 유탄을 발사할 수 있다. \r\n카피탕의 전술 크로스보우처럼 재장전이 필요없고 유탄의 종류를 바꿔가며 사용할 수 있다.", "조피아");
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            MessageBox.Show("능력 1 : 모든 방어팀 요원의 스마트폰 사용을 잠시 마비시키고, 강제로 진동이 울린다. \r\n시끄러운 진동 소리가 방어팀 요원의 위치를 노출시키고 진동하는 동안은 감시 카메라를 사용할 수 없다. \r\n감시 카메라 사용 중에 해킹당하면 도깨비가 해킹한 화면으로 전환되며 접속이 강제 종료된다. \r\n능력 2 : 도깨비가 있을때 방어팀 요원이 사망 시 스마트폰을 드랍하는데, 이것을 해킹하면 방어팀이 사용하는 모든 관측 도구 및 감시 카메라를 조작할 수 있다.", "도깨비");
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            MessageBox.Show("파괴 가능한 벽 또는 강화된 벽에 설치 방향에서만 건너편이 보이는 특수 방탄 유리를 설치한다. \r\n강화벽에 설치할 경우 강화한 안쪽 철제 면에서만 설치가 가능하다. \r\n설치면의 거울 하단에 있는 붉은색 산소 탱크를 파괴하면 벽 양면으로 수증기가 피어오르며 1초 후에 유리가 아래쪽으로 사출된다.", "미라");
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            MessageBox.Show("밟을 시 독침을 사출하는 원통형의 은폐 지뢰로 시작 시 1개가 주어지며 30초마다 하나씩 추가 지뢰를 얻어 최대 8개를 사용할 수 있다. \r\n고독 지뢰를 밟으면 2.5초마다 6의 지속 피해를 주며, 전력 질주 및 상호 작용이 불가능해진다.", "리전");
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            MessageBox.Show("투척하여 설치하는 점착식 지뢰로 벽, 천장, 바닥 등 모든 곳에 부착이 가능하며, 적이 범위 안에 접근하면 자동으로 작동하여 방향 감각 상실 효과를 준다. \r\n4초 동안 범위 내 대상의 이동 속도가 줄어들고 7초간 청각이 차단되며 시야를 어지럽힌다.", "엘라");
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            MessageBox.Show("드론과 카메라의 화면에서 자신의 모습을 감춘다. \r\n은폐 시 공격팀 드론과 더불어 적 도깨비에게 해킹당해 공격팀이 사용하고 있는 카메라에도 잡히지 않는 은폐 상태가 된다. \r\n드론과 은폐 상태의 비질의 거리가 12m 이내일 경우 드론 화면에 노이즈가 생기며 8m 내 접근 시 최대로 커지고, 비질의 화면에도 노이즈가 커지고 전자음이 들리기 시작한다. \r\n교란 효과에 영향을 받은 드론은 라이트가 노란색 대신 흰색으로 빛난다", "비질");
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            MessageBox.Show("탐지 능력을 발동하면 0.5초 간격으로 총 3회의 카운트다운 후 2초 동안 전 맵을 스캔하는데, 이 2초간의 스캔 시간 도중 방어팀이 움직이면 최초 포착 이후 3초간 1초 간격으로 빨간 색 핑을 통해 위치가 발각된다. \r\n라이온의 드론이 스캔 중 적을 감지하는 경우는 오직 적이 좌우앞뒤로 이동키를 입력했을 때 뿐이다. \r\n이동키를 누르지 않고 강제적으로 이동된 경우나 앉기, 포복, 사격, 기울이기, 가젯이나 강화벽 설치 등 이동을 제외한 행동은 발각되지 않는다. \r\n뮤트의 신호 방해기로 보호받고 있다면 신호 방해기의 범위 내에서는 스캔 도중 움직여도 발각되지 않는다.", "라이온");
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            MessageBox.Show("일정 시간 동안 아군 전체에게 10초 동안 20의 추가 최대 체력과 반동 제어력 향상, 정조준 시간 감소의 버프를 부여한다. \r\n거리 제한이 없으며 능력 사용 시 부상 상태의 아군 또한 회복시켜 일으켜 세울 수 있다. \r\n다만 핀카 본인이 부상당했을 때는 사용할 수 없다. \r\n만약 핀카 자신이 부상당하기 직전에 특수 능력이 사용됐을 경우 부상 직후 일어날 수도 있다. \r\n단, 심문당하고 있거나 프로스트의 덫에 걸린 아군은 못 일으킨다. \r\n부상당한 아군이 나노봇으로 소생될 경우 지속 시간 동안 50의 체력을 얻으며, 10초의 지속 시간이 끝나면 체력이 30으로 줄어든다. \r\n버프가 적용되는 동안 엘라의 진탕탄이나 섬광탄의 효과 지속 시간이 약 1초로 감소되며, 섬광탄의 경우는 근거리에서 맞아도 충분히 시야가 확보된다. \r\n또한 아드레날린 사용 시 철조망이나 멜루시의 밴시에 의한 이동속도 감소도 줄어들어 철조망이나 밴시를 빠르게 통과할 수 있다.", "핀카");
        }

        private void pictureBox50_Click(object sender, EventArgs e)
        {
            MessageBox.Show("강화벽을 포함한 벽 및 바닥에 구멍을 낼 수 있는 돌파용 토치. \r\n자르는 형상을 사용자 마음대로 할 수 있기 때문에 크게 구멍을 내는 것도 가능하지만 긴 줄의 형태로 구멍 내거나 작은 구멍 하나만 내서 매버릭이나 아군이 사격각을 보는 용도로도 사용할 수 있다. \r\n토치를 장비하고 있는 도중에는 다른 자세를 취할 수 있으나 기울이기를 사용할 수 없다.", "메버릭");
        }

        private void pictureBox49_Click(object sender, EventArgs e)
        {
            MessageBox.Show("유탄발사기로 원거리에서 벽이나 바닥, 천장에 기압탄을 발사하여 부착시킨다. \r\n기압탄은 적이 감지 범위 내로 들어오면 자동으로 격발하며 폭풍을 일으켜 적을 일정거리 밀어내고 넘어뜨린다. \r\n아군의 움직임에는 격발하지 않지만 기압탄이 적 때문에 격발할 때 기압탄의 폭풍범위 안에 본인이나 아군이 함께 있었다면 적과 함께 넘어진다. \r\n폭풍으로 적이나 아군이 넘어질 때 날아가는 경로에 파괴 가능한 벽, 바리게이트, 캐슬의 방탄 패널, 이동식 방패가 있다면 몸이 부딪치며 그것들 또한 파괴하면서 넘어진다. \r\n또한 기압탄에 의해 파괴 가능한 벽으로 넘어질 경우 5의 대미지를 입는다. \r\n설치된 기압탄은 작고 주기적인 소리를 내고, 다시 회수가 불가능하기 때문에 신중하게 사용할 필요가 있다.", "노매드");
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            MessageBox.Show("방탄 셔터와 레이저 발사기가 달린 카메라로 벽과 바닥에 부착 가능하며, 연막을 투사해서 볼 수 있다. \r\n방탄셔터가 닫힌 상태에서는 총격은 어느 방향이건 방어해내고 근접 공격에도 파괴되지 않지만 방탄 유리가 열려 있을 때는 총격이나 근접공격, 트위치의 감전드론으로 파괴할 수 있다. \r\n또 폭발물이나 슬레지의 파쇄 망치, 메버릭의 토치는 방탄셔터 개폐여부와 상관없이 악의 눈을 파괴할 수 있으며 악의 눈이 부착된 벽이 무너지면 악의 눈도 함께 파괴된다. \r\n악의 눈을 전기가 흐르는 강화벽에 설치할 경우 파괴된다.", "마에스트로");
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            MessageBox.Show("알리바이 자신의 모습을 닮은 홀로그램을 생성하는 장치로, 정십이면체로 이루어진 투영기 본체를 바닥에 던져 설치하면 길쭉하게 펼쳐지면서 그 위로 홀로그램이 생성된다. \r\n홀로그램은 투영기를 던진 방향을 쳐다보며 정조준 한 자세로 서있는 모습으로 생성되며, 공격팀이 홀로그램을 공격하거나 직접 접촉하면 그 즉시부터 5초 동안 0.75초 간격으로 해당 공격팀 오퍼레이터의 위치가 특수한 아이콘으로 지속해서 총 5번 노출된다.", "알리바이");
        }

        private void pictureBox60_Click(object sender, EventArgs e)
        {
            MessageBox.Show("원거리 전기 충격기가 장착된 확장형 방탄 유리 방패로 공격팀의 다른 방패들과는 달리 들고 나서 1~2초 후 방패가 자동으로 확장된다. \r\n몽타뉴의 확장 방패처럼 방패를 든 상태에서는 사격 및 근접 공격을 할 수 없으며, 앉거나 포복, 장애물 넘기도 불가능하다. \r\n방패 전체가 방탄유리로 되어있어 타 방패에 비해 시야 확보 면에서 압도적인 대신, 총격을 받으면 다른 방패와 마찬가지로 금이 가기 때문에 공격을 받을수록 시야 확보가 나빠진다. ", "클래시");
        }

        private void pictureBox59_Click(object sender, EventArgs e)
        {
            MessageBox.Show("어디든지 던져서 붙일 수 있는 고압 발전기이다. \r\n벽이나 바닥에 부착 후 집게발 주위에 원형으로 범위가 표시되고 그 범위 테두리까지 천천히 진한 흰색 원이 차오르며 이 원이 테두리를 전부 채우면 작동하여 전류를 흘려보낸다. \r\n전기가 흐를 수 있는 강화벽과 철조망, 이동식 방패가 집게발의 작동범위 내에 있으면 전류가 흐르게 된다.", "카이드");
        }

        private void pictureBox48_Click(object sender, EventArgs e)
        {
            MessageBox.Show("던져놓으면 시간이 지나며 자동으로 바닥에 설치되는 이동방해 장비. \r\n트랙스를 바닥에 던지면 트랙스에서 정육각형 모양으로 6개의 트랙스가 반시계방향으로 1차로 추가 배치되며, 이후 1차로 배치된 6개의 트랙스마다 각각 2개의 트랙스를 반시계방향으로 추가 배치해서 총 19개의 트랙스가 정육각형 모양으로 설치된다. \r\n모든 트랙스가 배치될 떄까지 총 9초가 걸린다. \r\n트랙스가 추가로 배치되어야하는 부분의 공간이 부족하면 트랙스끼리의 공간이 좁게 설치돼서 찌그러진 육각형 모양이 되거나 트랙스가 추가로 배치될 공간이 아예 없다면 배치되지 않을 수도 있다.", "그리드락");
        }

        private void pictureBox47_Click(object sender, EventArgs e)
        {
            MessageBox.Show("방어팀의 카메라에서 뇌크의 모습이 지워지며 뇌크가 발생시키는 소음 일부가 줄어든다. \r\n활성화 중에는 충전량이 점점 줄어들고 비활성화중에는 충전량이 다시 차오르는 충전방식으로 작동한다. \r\n자유롭게 켜고 끌 수 있지만 부상으로 쓰러지면 즉시 비활성화된다.", "뇌크(녹)");
        }

        private void pictureBox46_Click(object sender, EventArgs e)
        {
            MessageBox.Show("트랩도어와 창문에 사용할 수 있는 그래플링 훅으로, 일정거리 내에 있는 창문에 발동시 창문틀 근처에 X 모양의 4개의 지지대가 붙고 아마루가 가라 훅을 타고 날아간다. \r\n창문에 바리케이드가 설치되어 있을 때 가라 훅을 사용하면, 바리케이드는 가라 훅을 타고 창문으로 들어가는 시점에 부서지며, 강화되지 않은 일반 트랩도어는 미리 부수지 않아도 가라 훅을 타고 올라갈 수 있다. \r\n창문으로 진입하는 동안, 바로 앞에 적이 있다면 발차기(근접공격)로 즉사시킬 수 있다.", "아마루");
        }

        private void pictureBox45_Click(object sender, EventArgs e)
        {
            MessageBox.Show("능력을 벽이나 바닥에 부착시키면 잠시 뒤 폭발하여 폭발 범위 내에 있는 가젯과 벽 너머의 가젯을 전부 파괴한다. \r\n특히 강화벽이나 강화된 트랩도어에 부착시키면 강화벽 너머까지 폭발 범위가 확장되므로 적의 가젯이 영향 범위 내에 있다면 파괴할 수 있다. \r\n강화되지 않은 벽에는 작은 구멍이 뚫리지만 강화벽에는 폭발 흔적만 남고 구멍이 뚫리지 않는다. \r\n파괴할 수 없는 벽이나 바닥에 부착시키면 벽 너머의 가젯에는 영향을 주지 않으며 부착된 LV 폭발형 창은 잉의 칸델라처럼 폭발되기 전까지 총격으로 파괴가 가능하다.", "칼리");
        }

        private void pictureBox57_Click(object sender, EventArgs e)
        {
            MessageBox.Show("해충은 발동 범위 내에 들어온 드론에게 달라붙어 통제권을 빼앗으며, 드론 주변에 직접 발사해도 즉시 통제권을 빼앗을 수 있다. \r\n해킹이 성공적으로 완료되면 해충은 파괴되며 한 번 통제권을 빼앗긴 드론은 공격팀이 되찾을 수 있는 방법이 없어 공격팀에게는 반드시 파괴해야하는 방어팀 장비가 된다. ", "모지(찌)");
        }

        private void pictureBox56_Click(object sender, EventArgs e)
        {
            MessageBox.Show("스마트 안경을 활성화하면 플레이어 화면이 전체적으로 푸른색으로 변하고 모든 섬광 효과에 면역이 된다. \r\n이미 섬광 효과에 무력화 된 상태에서도 사용하면 실명효과를 즉시 없애준다. \r\n또 제한적인 연막투시 능력이 생기는데, 접이식 조준기를 사용중인 글라즈처럼 양 옆에 하얀색 게이지가 생기며 제자리에 움직이지 않고 있으면 게이지가 점점 차오르고 연막 내부를 투시하여 적을 관측할 수 있다. \r\n이 상태에서 다시 움직이면 게이지가 떨어지고 연막 투시 능력이 약화되다가 완전히 사라진다.", "워든");
        }

        private void pictureBox55_Click(object sender, EventArgs e)
        {
            MessageBox.Show("기본적인 기능은 이동식 방패와 동일하지만 이 뒤에 소이탄 트랩을 추가로 부착한다. \r\n소이탄 트랩은 후방에서의 총격이나 폭발물, 슬레지의 망치, 매버릭의 토치 등에 폭발하며 반경 3미터 이내에 지속 피해를 주는 불이 생성된다. \r\n폭발할 때 주변의 도구와 파괴 가능한 바닥 표면이 같이 파괴된다. \r\n폭발 피해는 장갑에 따라 다르며 이후 불길은 접근한 대원에게 0.7초가 지날 때 마다 12의 피해를 입힌다.", "고요");
        }

        private void pictureBox54_Click(object sender, EventArgs e)
        {
            MessageBox.Show("공격팀의 투척 가젯을 막는 일회용 도구로 던져서 천장이나 벽면에 부착시킬 수 있다. \r\n5m의 탐지 범위 내에 들어온 공격팀의 투척물이나 발사체를 자력을 발생시켜 Mag-NET쪽으로 끌어당겨 격발시킨다. \r\n한 번 발동하고 나면 Mag-NET 시스템은 자폭하지만 주변에 아무런 피해를 주지 않으며, 최초 부착시 방어가 활성화되기까지 카이드의 전기집게발처럼 약간의 시간이 필요하다. \r\n투척물 자체를 아예 제거하는 예거의 ADS와는 달리 Mag-NET 시스템은 끌어당겨온 투척물이 정상적으로 격발하기 때문에 투척물의 효과는 그대로 발생한다.", "와마이");
        }

        private void pictureBox44_Click(object sender, EventArgs e)
        {
            MessageBox.Show("야나 본인이 직접 조종 가능한, 공격과 레펠링 등 상호 작용의 행위를 제외한 달리기, 자세 변경, 장애물 뛰어넘기 등의 모든 행동을 할 수 있는 홀로그램 분신을 만들 수 있다. \r\n종류에 관계없이 피해를 입으면 사라지고, 홀로그램을 공격해도 위치가 노출되는 일은 없다. \r\n홀로그램은 야나의 전투복, 무장 부착물과 스킨을 전부 그대로 재현하며 발소리, 뭔가 넘는 소리, 철조망 지나는 소리 등을 포함한 소리까지 대원과 똑같이 낸다. \r\n심지어는 철조망을 지날 때 느려지는 것까지도 사람과 같다. \r\n무제한 충전식으로 횟수 제한은 없으나 적에게 잃으면 스스로 종료했을 때보다 재충전이 많이 오래 걸린다.", "야나");
        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            MessageBox.Show("벽에 부착된 셀마는 첫 번째 브리칭이 끝나면 중력을 받아 수직으로 내려면서 두 번째 브리칭을 자동으로 해나가며 2번의 브리칭이 모두 성공한다면 뛰어넘거나 앉아서 이동할 수 있는 구멍이 생기게 된다. \r\n구멍을 뚫을 수 없는 표면에 던지면 폭발이 시작되지 않고 에이스가 다시 회수할 수 있다.", "에이스");
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            MessageBox.Show("특수 능력 사용시 모지처럼 별도의 도구(ARGUS 발사기)를 사용해서 직사에 가깝게 설치하며, 설치된 ARGUS 카메라는 발키리의 칠흑의 주시자와 유사하게 시야를 제공한다. \r\n각 카메라당 1발의 레이저를 쏠 수 있는데, 대미지는 5로 미미하므로 주로 방어팀 가젯 파괴에 사용된다.", "제로");
        }

        private void pictureBox58_Click(object sender, EventArgs e)
        {
            MessageBox.Show("한 번에 최대 3회까지 쌓이는, 무제한 충전식 돌진 능력. \r\n사용하면 3 속도 대원보다 조금 더 빠른 속도로 질주한다. \r\n돌진을 통해 얇은 벽과 바리케이드를 들이받아 부술 수 있고, 벽을 뚫을 경우 5의 피해를 입는다. \r\n남은 체력이 5 이하인 경우에 벽에 박으면 벽을 부술 순 있지만 동시에 부상 상태가 된다. \r\n확장 방패를 사용중인 몽타뉴를 포함한 적 대원을 들이받으면 적을 해당 방향으로 날려버리며 잠시 무력화할 수 있다. \r\n돌진 도중과 돌진으로 벽이나 대원 등의 대상에 박은 직후 잠깐동안은 무기를 사용할 수 없다. \r\n적을 쓰러뜨린 경우 적이 일어나는 속도보다 오릭스가 더 빨리 사격을 할 준비가 완료되기에 1대1에서 들이받기에 성공했다면 무조건 유리하다. \r\n돌진은 노매드의 기압탄이나 그리드락의 트랙스 독침 등에 취소될 수 있다.", "오릭스");
        }

        private void pictureBox53_Click(object sender, EventArgs e)
        {
            MessageBox.Show("밴시의 사거리 내에 적 대원이 들어오면 이동속도를 느려지게 하고 특유의 음파 소리를 낸다. \r\n밴시가 작동하려면 적의 상체, 머리와 밴시 사이에 장애물이 없어야하기 때문에 설치 위치를 고려해야 한다. \r\n밴시는 방탄이므로 파괴하려면 폭발물을 사용하거나 근접 공격으로 파괴해야 한다. ", "멜루시");
        }

        private void pictureBox52_Click(object sender, EventArgs e)
        {
            MessageBox.Show("벽이나 창문과 문, 그리고 트랩도어에 설치할 수 있다.\r\n약간의 대기시간 후 레이저가 발동되며, 이 레이저는 공격팀이 지나가거나 투척물, 가젯, 드론 등이 통과할 때 발동되며 30의 피해를 주거나 투사체를 파괴한다. \r\n만약 활성화된 상태의 게이트에 방어팀이 근접할 경우 게이트는 비활성화되며 방어팀이 멀어지면 다시 활성화된다. \r\n어떠한 방법으로든 레이저를 통과하면 작동이 중지되고 스파크가 튀는 상태가 30초간 유지되며, 이후 특유의 소리와 함께 가젯이 충전되며 펼쳐지고, 펼쳐진 가젯에 사격을 가할 경우 다시 레이저가 활성화된다. \r\n주의할 점으로 이 레이저가 무력화되는 것은 아군의 투척물 또한 적용된다.", "아루니");
        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {
            MessageBox.Show("드론을 전개하면 10초의 작동 시간이 주어진다.\r\n방향키를 누르지 않아도 자동으로 앞으로 나아간다.\r\n방향 전환과 점프는 가능하나 후진과 정지는 불가능하다.\r\n심지어 드론 조종을 취소하더라도 앞으로 나아간다.\r\n전개 10초 후, 또는 할당된 버튼을 누르면 자폭 절차에 들어간다.\r\n자폭 절차에 들어가면 드론은 움직임을 멈추고 폭발물로만 부술 수 있는 방탄 상태가 되며 근처에 사람이 있을 경우 해당 플레이어의 HUD에 수류탄처럼 위험 경고 아이콘이 표시된다.\r\n드론은 밴딧과 카이드의 전기에는 파괴되며, 뮤트 재머에 걸릴 시 무력화 되지만, 재머가 파괴될 경우 전개시간에 상관없이 자폭절차가 작동된다.\r\n자폭절차 이전에 재머에 걸릴 경우 드론을 쉽게 파괴할 수 있다.\r\n벽, 또는 천장으로 점프한 상태에서 자폭 절차에 들어가면 그 벽이나 천장에 달라붙은 뒤 폭발한다.\r\n자폭 절차에 들어가면 플로레스는 약간의 딜레이 후 드론 조종 모드에서 강제로 벗어나게 된다.\r\n3초 후 드론은 자폭한다.\r\n 폭발 위력은 방어팀의 C4와 비슷하다.", "플로레스");
        }
    }
}
