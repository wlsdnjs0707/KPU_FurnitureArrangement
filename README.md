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

AR 기술을 이용한 가구 배치 애플리케이션
</br>

## [Thesis](https://drive.google.com/file/d/1z1_LuE23bzVGHNES-6Try46LxLytE1zr/view?usp=drive_link)

## Features
![슬라이드4](https://github.com/user-attachments/assets/470bc4c6-f824-4d5a-8334-24c4d30c0f21)

## Developers

[김진원](https://github.com/wlsdnjs0707) - 증강현실(AR) 가구배치 기능 구현

[이재솔](https://github.com/jaesol0105) - 안드로이드 애플리케이션 구현

[최정인](https://github.com/bombab) - CNN 이미지 분류 모델 구현

## Development
### Language
* C#
* Kotlin
* Python
### Frameworks
* AR Core
* TensorFlow
* Keras
### Tools 
* Unity
* Android Studio
* Google Colab (Jupyter Notebook)
### Hardware Platforms
* Devices running Android 7.0 operating system
### Development Environment
* Windows

## System Architecture Diagram
![슬라이드7](https://github.com/user-attachments/assets/3c15d9b9-f644-4b3f-a134-87eaa005f1d3)

## Screens
![슬라이드1](https://user-images.githubusercontent.com/86781939/169832565-fd7c5f08-5d6b-47cd-b8cc-f42214c66474.png)


## Articles
Android - [Unity 프로젝트 연동, Unity 프로젝트가 실행되는 순간 앱이 종료되는 문제 해결](https://github.com/jaesol0105/ar_furniture_application_prototype?tab=readme-ov-file#ar-foundation-%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8-%EC%97%B0%EB%8F%99)

## Functions

### 1-1. 가구 배치
카메라로 인식한 평면에 터치로 오브젝트 생성
```cs
if (!spawnObject) // 오브젝트가 존재하지 않으면
{
  // 터치한 포지션과 로테이션 정보로 평면에 오브젝트 생성
  spawnObject = Instantiate(placeObject, hitPose.position, hitPose.rotation);
}
```

### 1-2. 가구 이동
배치된 가구를 이동
```cs
else // 오브젝트가 이미 존재하면
{
  // 스폰된 오브젝트의 포지션을 터치한 위치로 이동
  spawnObject.transform.position = hitPose.position;
}
```

### 1-3. 가구 회전
배치된 가구를 버튼을 이용해 왼쪽, 오른쪽으로 회전
```cs
if (isButtonDown) // PointerDown 이벤트에서 true, PointerUp 이벤트에서 false
{
  // 오른쪽 회전: -90.0f, 왼쪽 회전: 90.0f
  ARPlaceOnPlane.spawnObject.transform.Rotate(0.0f, -90.0f * Time.deltaTime, 0.0f);
}
```

### 1-4. 벽 예외처리
수직 평면(벽)에는 가구가 배치되지 않게 함
```cs
// arPlaneManager에서 가져온 평면의 속성 중 alignment (Vertical, Horizontal) 구분
// HorizontalUp, HorizontalDown 일 경우 이동 
if (arPlaneManager.GetPlane(hits[0].trackableId).alignment == PlaneAlignment.HorizontalUp || arPlaneManager.GetPlane(hits[0].trackableId).alignment == PlaneAlignment.HorizontalDown)
{
  spawnObject.transform.position = hitPose.position;
}
```
### 1-5. 생성할 가구 변경
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
