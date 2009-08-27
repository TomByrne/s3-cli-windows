<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ec2="http://ec2.amazonaws.com/doc/2008-12-01/" exclude-result-prefixes="ec2">
    <xsl:output method="xml" omit-xml-declaration="no" indent="yes"/>
    <xsl:variable name="ns" select="'http://ec2.amazonaws.com/doc/2008-12-01/'"/>
    <xsl:template match="ec2:ConfirmProductInstanceResponse">
        <xsl:apply-templates select="ec2:return"/>
    </xsl:template>
    <xsl:template match="ec2:return">
        <xsl:if test=". = 'true'">
            <xsl:element name="ConfirmProductInstanceResponse" namespace="{$ns}">
                <xsl:element name="ResponseMetadata" namespace="{$ns}">
                    <xsl:element name="RequestId" namespace="{$ns}">
                        <xsl:value-of select="ec2:requestId"/>
                    </xsl:element>
                </xsl:element>
                <xsl:element name="ConfirmProductInstanceResult" namespace="{$ns}">
                    <xsl:element name="OwnerId" namespace="{$ns}">
                        <xsl:value-of select="../ec2:ownerId"/>
                    </xsl:element>
                </xsl:element>
            </xsl:element>
        </xsl:if>
        <xsl:if test="not(. = 'true')">
            <xsl:element name="ErrorResponse" namespace="{$ns}">
                <xsl:element name="Error" namespace="{$ns}">
                    <xsl:element name="Type" namespace="{$ns}">Receiver
                    </xsl:element>
                    <xsl:element name="Code" namespace="{$ns}"/>
                    <xsl:element name="Message" namespace="{$ns}">Unable successfully attach product code to instance
                    </xsl:element>
                    <xsl:element name="Detail" namespace="{$ns}"/>
                </xsl:element>
                <xsl:element name="RequestId" namespace="{$ns}"/>
            </xsl:element>
        </xsl:if>
    </xsl:template>
</xsl:stylesheet>
