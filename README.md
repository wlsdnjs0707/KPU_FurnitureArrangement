# 2021 KPU Capstone Project

[![Kotlin](https://img.shields.io/badge/Kotlin-1.5.20-blue.svg)](https://kotlinlang.org)
[![Gradle](https://img.shields.io/badge/gradle-7.0.2-green.svg)](https://gradle.org/)
[![Android Studio](https://img.shields.io/badge/Android%20Studio-4.0-green)](https://developer.android.com/studio)
[![minSdkVersion](https://img.shields.io/badge/minSdkVersion-24-red)](https://developer.android.com/distribute/best-practices/develop/target-sdk)
[![targetSdkVersion](https://img.shields.io/badge/targetSdkVersion-30-orange)](https://developer.android.com/distribute/best-practices/develop/target-sdk)
<br>
[![Unity](https://img.shields.io/badge/Unity-2020.3.26.f1-darkgray.svg)](https://kotlinlang.org)
[![AR Core](https://img.shields.io/badge/AR%20Core-4.1.9-violet)](https://developer.android.com/distribute/best-practices/develop/target-sdk)
[![TensorFlow](https://img.shields.io/badge/TensorFlow-2.8.0-darkorange)](https://developer.android.com/distribute/best-practices/develop/target-sdk)

### AR 기술을 이용한 가구 배치 애플리케이션
</br>
 
## # 역할분담

김진원 - 증강현실 가구배치 기능 구현

최정인 - CNN 이미지 분류 모델 구현

이재솔 - 유니티 프로젝트와 CNN모델을 안드로이드 어플리케이션으로 통합
</br></br>

## # 1. 요약
<img src="https://user-images.githubusercontent.com/86781939/201742932-c738bdd9-b737-4234-8cb2-bd3f3669258c.PNG"  width="551" height="315" >

## # 2. 주요 기능

### 2-1. 가구 배치
카메라로 인식한 평면에 터치로 오브젝트 생성
```cs
if (!spawnObject) // 오브젝트가 존재하지 않으면
{
  // 터치한 포지션과 로테이션 정보로 평면에 오브젝트 생성
  spawnObject = Instantiate(placeObject, hitPose.position, hitPose.rotation);
}
```

### 2-2. 가구 이동
배치된 가구를 이동
```cs
else // 오브젝트가 이미 존재하면
{
  // 스폰된 오브젝트의 포지션을 터치한 위치로 이동
  spawnObject.transform.position = hitPose.position;
}
```

### 2-3. 가구 회전
배치된 가구를 버튼을 이용해 왼쪽, 오른쪽으로 회전
```cs
if (isButtonDown) // PointerDown 이벤트에서 true, PointerUp 이벤트에서 false
{
  // 오른쪽 회전: -90.0f, 왼쪽 회전: 90.0f
  ARPlaceOnPlane.spawnObject.transform.Rotate(0.0f, -90.0f * Time.deltaTime, 0.0f);
}
```

### 2-4. 벽 예외처리
수직 평면(벽)에는 가구가 배치되지 않게 함
```cs
// arPlaneManager에서 가져온 평면의 속성 중 alignment (Vertical, Horizontal) 구분
// HorizontalUp, HorizontalDown 일 경우 이동 
if (arPlaneManager.GetPlane(hits[0].trackableId).alignment == PlaneAlignment.HorizontalUp || arPlaneManager.GetPlane(hits[0].trackableId).alignment == PlaneAlignment.HorizontalDown)
{
  spawnObject.transform.position = hitPose.position;
}
```
### 2-5. 생성할 가구 변경
가구 변경 버튼에 onClick 이벤트 할당
```cs
//Resources 폴더에 모델링 저장해두고 Load 하여 사용
GameObject officeChair = Resources.Load<GameObject>("OfficeChair");
if (officeChair != null)
{
  // 생성할 오브젝트 변경
  spawnObject = Instantiate(officeChair);
}
```
<br>

## # 3. 테스트
<img src="https://user-images.githubusercontent.com/86781939/169832565-fd7c5f08-5d6b-47cd-b8cc-f42214c66474.png"  width="800" height="600" >
