pipeline {
    agent any

    stages {

        stage('Checkout Code') {
            steps {
                git branch: 'main',
                    url: 'https://github.com/Nikhilmvk/dotnet-sql-cicd.git'
                // or just 'checkout scm' here because Jenkins already checked out
            }
        }

        stage('Build Docker Image') {
            steps {
                sh 'docker build -t dotnet-sql-ui-app .'
                bat 'docker build -t dotnet-sql-ui-app .'
            }
        }

        stage('Deploy') {
            steps {
                sh '''
                docker stop dotnet-api || true
                docker rm dotnet-api || true
                bat '''
                docker stop dotnet-api
                docker rm dotnet-api

                docker run -d -p 5000:8080 \
                  --name dotnet-api \
                docker run -d -p 5000:8080 ^
                  --name dotnet-api ^
                  dotnet-sql-ui-app
                '''
            }
        }
    }
}
