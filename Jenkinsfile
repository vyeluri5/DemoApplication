pipeline {
  options {
    buildDiscarder(logRotator(numToKeepStr: '5'))
    disableConcurrentBuilds()
  }
    agent any
    stage('Checkout'){
	checkout scm
	} 
    stage('Container Build') {
	sh "docker build -t demoapp:B${BUILD_NUMBER} -F Dockerfile ."
        }
    
}
