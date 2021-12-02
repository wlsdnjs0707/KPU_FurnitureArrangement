# clone
```
# git clone https://github.com/wlsdnjs0707/kpu_Arrangement.git
```

# 브랜치 생성
```
# git branch jinjin19 
```
 ###### 내가 작업할 branch
 팀원은 각각 자신의 PC에서 branch를 생성해서 독립된 작업 공간을 마련.<br>
 팀원은 각자 구현할 기능이 정해져 있으며, 각 기능을 끝낼 때 마다 깃헙에 자신의 branch 작업본을 push 한다.<br>

# 브랜치 이동하기
```
# git checkout master
```
 master branch로 이동.
<br>
```
# git checkout jinjin19
```
 내 branch로 이동
 
# 브랜치 병합하여 push 하기
```
# git add .
# git commit -m "기능 구현 완료" //1. 내 브랜치에서 커밋

# git checkout master //2. 마스터 브랜치로 이동
# git merge jinjin19  //3. 내 브랜치를 병합.
# git push origin master //4. 로컬저장소(pc)의 마스터 브랜치에서, 원격저장소(github)의 마스터 브랜치로 push.
```

# 작업 중 다른 팀원이 push 했다면?
### 내 로컬저장소(pc의 작업영역)를 최신버전으로 업데이트하고 작업을 진행.
```
# git checkout master //1. 마스터 브랜치로 이동
# git pull origin master //2. 다른 팀원이 push한 원격저장소(github)의 마스터 브랜치를 pull해서 가져옴.
```

 마스터 브랜치를 가져왔으면, 나의 branch에도 반영해야함.

```
# git checkout jaesol //3. 내 브랜치로 이동
# git merge master //4. 가져온 마스터 브랜치를 merge.
```


# 충돌 예방
팀원간은 사전에 작업할 코드 영역을 정하여 branch 병합시 충돌하는 일이 없도록한다.<br>
만약 충돌시 상의 후 한 사람 코드를 지우면됨.
