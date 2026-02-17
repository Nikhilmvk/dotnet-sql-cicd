pipeline {
    agent any

    stages {

        stage('Checkout Code') {
            steps {
                git branch: 'main',
                    url: 'https://github.com/Nikhilmvk/dotnet-sql-cicd.git'
            }
        }

        stage('Build Docker Image') {
            steps {
                bat 'docker build -t dotnet-sql-ui-app .'
            }
        }

        stage('Deploy') {
            steps {
                bat '''
                docker stop dotnet-api
                docker rm dotnet-api

                docker run -d -p 5000:8080 ^
                  --name dotnet-api ^
                  dotnet-sql-ui-app
                '''
            }
        }
    }
}
