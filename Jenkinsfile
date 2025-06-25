pipeline {
    agent any

    environment {
        DOTNET_CLI_HOME = "${env.WORKSPACE}"
    }

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/raviprasad-y/RestSharpAPIAutomation.git'
            }
        }

        stage('Restore Dependencies') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build Project') {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Run Tests') {
            steps {
                bat 'dotnet test --configuration Release --logger "trx;LogFileName=test_results.trx"'
            }
        }

        stage('Generate Test Report') {
            steps {
                bat 'dotnet new tool-manifest --force'
                bat 'dotnet tool install dotnet-reportgenerator-globaltool'
                bat 'dotnet tool run reportgenerator -reports:**/test_results.trx -targetdir:TestResults -reporttypes:Html'
            }
        }
        stage('Publish Report') {
            steps {
                publishHTML([
                    reportDir: 'TestResults',
                    reportFiles: 'index.html',
                    reportName: 'RestSharp API Test Report'
                ])
            }
        }
    }

    post {
        always {
            echo 'Pipeline completed.'
        }
    }
}
