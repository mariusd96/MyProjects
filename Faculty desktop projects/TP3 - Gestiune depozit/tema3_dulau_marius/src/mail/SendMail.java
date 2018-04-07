package mail;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.Date;
import java.util.Properties;
import java.util.Scanner;

import javax.mail.*;
import javax.mail.internet.*;
import javax.activation.*;

public class SendMail {
	
	private String mailFrom;
	private String password;
	private static final String Path = "C:/mail_tema3.txt";
	private Scanner scan;
	
	public SendMail()
	{
		try {
			scan = new Scanner(new File(Path));
			mailFrom = scan.nextLine();
			password = scan.nextLine();
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	public void sendMail(String mailTo, String attachFiles)
	{
		 String host = "smtp.gmail.com";
	     String port = "465";
	 
	     // message info
	     String subject = "Bill";
	     String message = "Here is your bill from warehouse.";
	 
	     try 
	     {
	    	 sendMailWithAttachment(host, port, mailFrom, password, mailTo, subject, message, attachFiles);
	         System.out.println("Email sent.");
	     } 
	     catch (Exception ex) 
	     {
	    	 System.out.println("Could not send email.");
	         ex.printStackTrace();
	     }
	}

	public void sendMailWithAttachment(String host, String port, String userName, String password, String toAddress, String subject, String message, String attachFiles) throws AddressException, MessagingException
	{
		// sets SMTP server properties
		Properties props = new Properties();
		props.put("mail.smtp.host", host);
		props.setProperty("mail.smtp.socketFactory.port", port);
		props.setProperty("mail.smtp.socketFactory.class", "javax.net.ssl.SSLSocketFactory");
		props.put("mail.smtp.auth", "true");
		props.put("mail.smtp.port", port);
		props.put("mail.user", userName);
        props.put("mail.password", password);
        
        // creates a new session with an authenticator
        Session session = Session.getInstance(props, new javax.mail.Authenticator() {
        		protected PasswordAuthentication getPasswordAuthentication() 
        		{
        			return new PasswordAuthentication(userName, password);
        		}
        });
 
        // creates a new e-mail message
        try
        {
        	Message msg = new MimeMessage(session); 
        	msg.setFrom(new InternetAddress(userName));
        	msg.addRecipients(Message.RecipientType.TO, InternetAddress.parse(toAddress));
        	msg.setSubject(subject);
        	msg.setText(message);
        	//Transport.send(msg);
        
        	MimeBodyPart messageBodyPart = new MimeBodyPart();
        	messageBodyPart.setContent(message, "text/html");
        
        	// creates multi-part
        	Multipart multipart = new MimeMultipart();
        	multipart.addBodyPart(messageBodyPart);
 
        	// adds attachments
        	MimeBodyPart msgBodyPart = new MimeBodyPart();
        	DataSource source = new FileDataSource(attachFiles);
        	msgBodyPart.setDataHandler(new DataHandler(source));
        	msgBodyPart.setFileName(attachFiles);
        	multipart.addBodyPart(msgBodyPart);
        	msg.setContent(multipart);
        	
        	Transport transport = session.getTransport("smtp");
        	transport.connect(host, userName, password);
        	transport.sendMessage(msg, msg.getAllRecipients());
        	transport.close();
        }
        catch(Exception ex)
        {
        	ex.printStackTrace();
        }
	}
}
